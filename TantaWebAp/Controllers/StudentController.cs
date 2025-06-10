using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;

namespace TantaWebAp.Controllers
{
    public class StudentController : Controller
    {
        //Student/all
        public IActionResult All()
        {
            //get data frm model
            StudentBL studentBL = new StudentBL();
            List<Student> stdList= studentBL.GetAll();
            //send to view
            return View("ShowAll",stdList);
            //View With name Showall
            //send Model type "List<student>"
        }
    }
}
