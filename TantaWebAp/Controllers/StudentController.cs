using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;

namespace TantaWebAp.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        //Student/all
        public IActionResult All()
        {
            //get data frm model
            List<Student> stdList= studentBL.GetAll();
            //send to view
            return View("ShowAll",stdList);
            //View With name Showall
            //send Model type "List<student>"
        }
        public IActionResult Details(int id)
        {
            Student stdModel=studentBL.GetById(id);
            if (stdModel != null)
            {
                return View("Details", stdModel);//View Details ,Model Student
            }
            else
            {
                //return View("Error");
                return NotFound();
            }
        }
    }
}
