using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;

namespace TantaWebAp.Controllers
{
    public class BindController : Controller
    {
        //test Primitive Paramters (int ,string,[])
        //Bind/TestPrimitive/155?name=ahmed&age=12&color=red "GEt"
        //Bind/TestPrimitive?name=ahmed&age=12&id=155 "GEt"
        //http://localhost:15126/Bind/TestPrimitive?color[1]=red&color[0]=blue
        public IActionResult TestPrimitive(int age,string name,int id,string[] color)
        {
            return Content($"{age}\t{name}");
        }

        //Collection "List |Dictioary"
        //Bind/TestDic?name=christen&Phones[Ahmed]=123&phones[mohamed]=456
        public IActionResult TestDic(string name,Dictionary<string,string> phones)
        {
            return Content("");
        }


        //Complex Class
        //Bind/testObj?Id=1&name=SD&ManagerName=ahmed
        //http://localhost:15126/Bind/testObj?Id=1&name=SD&ManagerName=ahmed&Employees[0].Name=christen
        public IActionResult testObj(Department dept)
        //public IActionResult testObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        {
            return Content("");

        }
    }
}
