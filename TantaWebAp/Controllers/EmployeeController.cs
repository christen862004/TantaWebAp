using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;
using TantaWebAp.ViewModels;

namespace TantaWebAp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //int counter = 0;//state "value"
        public EmployeeController()
        {
            
        }
        public IActionResult Details(int id)
        {
            //Extra Info | not relatedd infor
            string msg = "Hello";
            int temp = 20;
            List<string> brch = new() {"NewCapital","Tanta","Alex","Smart"};
            //Send ddata from Action to View USing ViewData dictionary
            ViewData["Message"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = brch;
            ViewData["Color"] = "red";
            ViewBag.Fontsize = "20px";
            ViewBag.Color = "Blue";//ViewData["Color"] ="Blue" override


            Employee empModel= context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",empModel);
            //View edtails  ,Model with type Employee
        }

        public IActionResult DetailsVM(int id) {
            //collect data
            string msg = "Hello";
            int temp = 20;
            List<string> brch = new() { "NewCapital", "Tanta", "Alex", "Smart" };
            Employee empModel= context.Employees.FirstOrDefault(e => e.Id == id);

            //decalre viewMode Object
            EmployeeNameWithColorBrchListMsgTempViewModel EmpVM = new();
            //MApping 
            EmpVM.EmpId = empModel.Id;
            EmpVM.EmpName = empModel.Name;
            EmpVM.Branches= brch;
            EmpVM.Temp = 20;
            EmpVM.Message = msg;

            //Send VM to View

            return View("DetailsVM", EmpVM);
            //View : DetailsVM
            //Model : EmployeeNameWithColorBrchListMsgTempViewModel

        }
    }
}
