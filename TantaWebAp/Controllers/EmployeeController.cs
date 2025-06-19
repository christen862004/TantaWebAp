using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TantaWebAp.Models;
using TantaWebAp.Repository;
using TantaWebAp.ViewModels;

namespace TantaWebAp.Controllers
{
   
    public class EmployeeController : Controller
    {
        //  ITIContext context = new ITIContext();
        
        
        IEmployeeRepository EmpRepository;
        IDepartmentRepository DeptRepository;
        //int counter = 0;//state "value"
        //IOC | DIP using Design patter
        public EmployeeController(IEmployeeRepository empREpo,IDepartmentRepository deptRepo)
        {
            EmpRepository = empREpo;// new EmployeeRepository();
            DeptRepository = deptRepo;// new DepartmentRepository();
        }
        #region Index
        
        public IActionResult Index()
        {
            return View("Index", EmpRepository.GetAll());
        }
        #endregion


        #region Validation Remote
        //Employee/CheckSalary?Salary=10000 :GET
        public IActionResult CheckSalary(int Salary,string Name)//name from req
        {
            //db any logic nt found builtin 
            if (Salary > 7000)
                return Json(true);//valid
            else
                return Json(false);
        }
        #endregion

        #region NEwUSing Tag Hepler
        public IActionResult New()
        {
            //
            // IEnumerable<SelectListItem> asd = context.Departments.ToList();
            ViewBag.DeptList = DeptRepository.GetAll();
            return View("New");
        }
        [HttpPost]//can hande only post req
        [ValidateAntiForgeryToken]//can handel internal req only
        public IActionResult SaveNew(Employee EmpFromReq)
        {
            if(ModelState.IsValid==true)//only server
            {
                try
                {
                    EmpRepository.Add(EmpFromReq);
                    EmpRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //add error modelstate
                    //ModelState.AddModelError("DepartmentId", "Please Select Department");
                    ModelState.AddModelError("AnyKey",ex.InnerException.Message);//div
                }
            }
            ViewBag.DeptList =DeptRepository.GetAll();
            return View("New", EmpFromReq);
        }
        #endregion


        #region Edit
        public IActionResult Edit(int id)
        {
            Employee empFromDb = EmpRepository.GetById(id);

            if(empFromDb != null) {
                List<Department> departmentList =DeptRepository.GetAll();
                //decalr
                EmployeeWithDeptListViewModel empVM=new EmployeeWithDeptListViewModel() { 
                Id=empFromDb.Id,
                Name=empFromDb.Name,
                Salary=empFromDb.Salary,
                ImageURL=empFromDb.ImageURL,
                DepartmentId=empFromDb.DepartmentId,
                DeptList= departmentList,
                Email=empFromDb.Email
                };
                //map
                //send viewmodel
                return View("Edit", empVM);
            }
            return NotFound();
        }
     
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFromReq)
        {
            if(EmpFromReq.Name!=null & EmpFromReq.Salary > 7000)
            {
                //org ref
                Employee empFromDb=new Employee();
                //change
                empFromDb.Salary=EmpFromReq.Salary;
                empFromDb.Name=EmpFromReq.Name;
                empFromDb.ImageURL=EmpFromReq.ImageURL;
                empFromDb.Email=EmpFromReq.Email;
                empFromDb.DepartmentId=EmpFromReq.DepartmentId;
                EmpRepository.Update(empFromDb);
                //saveChange
                EmpRepository.Save();
                return RedirectToAction("Index");
            }
            //viewbag
            EmpFromReq.DeptList =DeptRepository.GetAll();//refill attend "Fieldd in request data"
            return View("Edit", EmpFromReq);
        }
        #endregion


        #region Details
        public IActionResult Details(int id,string name)
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


            Employee empModel= EmpRepository.GetById(id);
            return View("Details",empModel);
            //View edtails  ,Model with type Employee
        }

        public IActionResult DetailsVM(int id) {
            //collect data
            string msg = "Hello";
            int temp = 20;
            List<string> brch = new() { "NewCapital", "Tanta", "Alex", "Smart" };
            Employee empModel = EmpRepository.GetById(id);

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
        #endregion

    }
}
//Validation
//Security