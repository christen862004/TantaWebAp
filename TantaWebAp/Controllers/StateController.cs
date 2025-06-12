using Microsoft.AspNetCore.Mvc;

namespace TantaWebAp.Controllers
{
    //Http Protocol :StatesLess Protocol
    public class StateController : Controller
    {
        public IActionResult SetSession(int age,string name)
        {
            //logic "Store Ddata In Server "Secure"
            //serlaiaze object to josn
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session save success");
        }
        //get 
        public IActionResult GetSession()
        {
            //logic
            string n= HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"NAme= {n} \n age={a}");
        }


        public IActionResult SetCookie(int age,string name)
        {
            //logic
            //Session Cookie
            // HttpContext.Response.Cookies.Append("Name", name);

            //Presistent Cookie (Life Type days)
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Name", name,options);
            HttpContext.Response.Cookies.Append("Age", age.ToString(), options);
            return Content("Cookie Save Success");
        }
        public IActionResult GetCookie()
        {
            string name= HttpContext.Request.Cookies["Name"];
            string age= HttpContext.Request.Cookies["Age"];
            return Content($"Data From Cookie name={name}\t age={age}");
        }

        #region Befor Statmanament


        //int Age;
        //string NAme;
        //public IActionResult SetData(int age,string name)
        //{

        //    Age = age;//Save State
        //    NAme = name;//Save State
        //    return Content("Ok");
        //}

        //public IActionResult DisplayData() 
        //{
        //    return Content($"{Age} \t {NAme}"); 
        //}
        #endregion
    }
}
