using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TantaWebAp.Filtters;
using TantaWebAp.Models;
using TantaWebAp.Repository;

namespace TantaWebAp.Controllers
{
    //[HandelError]
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)//inject
        {
            this.service = service;
        }


        //ann +auth
        public IActionResult Welcome()
        {
            //User.IsInRole()
            if (User.Identity.IsAuthenticated)// == true)
            {
                //autho welomce name
                Claim IdClaim= User.Claims.FirstOrDefault(c => c.Type ==ClaimTypes.NameIdentifier);
                string id = IdClaim.Value;
                //Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Address");

                return Content($"welcome {User.Identity.Name} \t id={id} \t ");//Address={AddressClaim.Value}");

            }
            //anonums welcome Gust
            return Content("welcome Gust");
        }









        //Service/Index
        public IActionResult Index()// (IService ser,Employee emp)
        {
            ViewBag.Id = service.Id;
            return View();
        }
        
        [HandelError]
        public IActionResult Method1()
        {
            throw new Exception("Some Exception happen");
        }
        //Service/MEthod2
     //   [HandelError]
        public IActionResult Method2()
        {
            throw new Exception("Some Exception happen");
        }
    }
}
