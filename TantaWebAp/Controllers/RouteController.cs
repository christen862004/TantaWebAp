using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TantaWebAp.Controllers
{
    //r/MEthod1
    //r/MEthod2
    public class RouteController : Controller
    {
        //Route/MEthod1
        //r1 (one segment r1=>Route ,MEtho1)
        //r1?name=ahmed&age=13   not accept
        //r1/13/ahmed   ==>name,age Request.RouteValues
        //r1/23/Mohamed
        //r1/50/christen  //3 segment
        //r1/50           //2 segment
        //r1/ahmed/13 reject
        [Route("r1/{age:int:range(20,60)}/{name?}",Name ="RoutAtt")]
        //this rout will be the only rout to reach to this controller action
        
        public IActionResult Method1(string name,int age)
        {
            return Content("M1");
        }
        //Route/MEthod2
        //r2 (one segment r2=>Route ,MEtho2)
        
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
