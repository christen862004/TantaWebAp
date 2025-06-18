using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;
using TantaWebAp.Repository;

namespace TantaWebAp.Controllers
{
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
    }
}
