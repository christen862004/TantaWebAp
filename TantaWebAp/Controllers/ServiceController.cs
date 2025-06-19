using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
