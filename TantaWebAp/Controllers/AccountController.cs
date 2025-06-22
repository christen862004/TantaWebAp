using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;
using TantaWebAp.ViewModels;

namespace TantaWebAp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//username,address,password ,conf
        public async Task<IActionResult> Register(RegisterUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //save db
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userFromReq.UserName,
                    PasswordHash = userFromReq.Password,
                    Address = userFromReq.Address
                };
                IdentityResult result=await userManager.CreateAsync(user,userFromReq.Password);
                if(result.Succeeded)
                {
                    //create cookie with default claims (id,name,[email],[roles])
                    await signInManager.SignInAsync(user, false);//collection infor store cookie(id,name,email,role)
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(userFromReq);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFRomREquest)
        {
            if (ModelState.IsValid)
            {
                //check Cookie
                ApplicationUser userformDB=await userManager.FindByNameAsync(userFRomREquest.UserName);
                if(userformDB != null)
                {
                    bool found=await userManager.CheckPasswordAsync(userformDB,userFRomREquest.Password);
                    if (found)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userformDB, userFRomREquest.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userFRomREquest);
        }
        #endregion

        #region Logout
        public async  Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }
}
