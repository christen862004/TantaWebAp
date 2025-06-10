using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;
using TantaWebAp.Models;

namespace TantaWebAp.Controllers
{
    /*
     1) public class
     2) Inherit from Controller
     3) Class Name End With Controller KeyWord
     */
    public class HomeController : Controller
    {
        /*
            Method Constrain(Action) Endpoint
            1) Must Be Public 
            2) Cant be Static
            3) Cant be OverLoad (only in one Case)
         */
        //Home/ShowMsg
        //public string ShowMsg()
        //{
        //    return " Hello From My first Endpoint";
        //}

        public ContentResult ShowMsg()
        {
            //logic

            //Decalre ContentResult
            ContentResult result = new ContentResult();
            //set data
            result.Content = " Hello From My first Endpoint";
            //return 
            return result;
        }
        public ViewResult ShowView()
        {
            //logic
            //ddeclare
            ViewResult result = new ViewResult();
            //set data
            result.ViewName = "View1";
            //return
            return result;
        }
        //Home/ShowMix?id=12&name=ahmed
        //Home/ShowMix/12?name=ahmed
        public IActionResult  ShowMix(int id,string name)
        {
            if (id % 2 == 0)
            {
                return View("View1");
            }
            else
            { 
                return Content("Hello");
            }
        }
        //[NonAction]
        //public ViewResult View(string viewNAme)
        //{
        //    ViewResult result = new ViewResult();
        //    //set data
        //    result.ViewName = viewNAme;
        //    //return
        //    return result;
        //}


        //action can return  "Actionresult ==> IActionResult"
        // Content ==> ContentResult  => 
        // View    ==> ViewResult
        // Json    ==> JsonResult
        // File    
        // NotFound==> NotFoundResult
        //......



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
