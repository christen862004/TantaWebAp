using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TantaWebAp.ViewModels;

namespace TantaWebAp.Controllers
{
    //allow anoumny
    //authanticated
    //Auth &&authorize
    [Authorize(Roles ="Admin")]//cookie and with role Admin
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            this.roleManager = _roleManager;
        }
        public IActionResult Create()//name 
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)//name 
        {
            if (ModelState.IsValid)
            {
                //save
                IdentityRole role = new IdentityRole();
                role.Name = roleFromReq.RoleName;
               IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("Create");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Create",roleFromReq);
        }
    }
}
