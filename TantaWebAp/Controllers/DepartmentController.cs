using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;
using TantaWebAp.Repository;

namespace TantaWebAp.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository deptRepository;
        public DepartmentController(IDepartmentRepository deptrepo)
        {
            deptRepository = deptrepo; //new DepartmentRepository();
        }
        [Authorize]//check cookie Identity ,login
        public IActionResult Index()
        {
            List<Department> deptList = deptRepository.GetAll();
            return View("Index",deptList);
        }
        //handel anchor tag to open view
        public IActionResult New()
        {
            return View("New");//Model=Null
        }
        //Department/SaveNew?Name=sd&ManagerName=ajha
        //action can handel get | Post normal"default"
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//string Name,string ManagerName)
        {
            //restrict can handel only post methpd
            //if(Request.Method == "POST")
            if (deptFromReq.Name != null)
            {
                //save
                deptRepository.Add(deptFromReq);
                deptRepository.Save();

                //Index(); //not normal action , cal action in antoeht controller
                return RedirectToAction("Index");//, "Department");
                                                    //return RedirectToAction("Index", "Department");
            }
            return View("New", deptFromReq);//view "New" Model :Department
        }


        //method "public ,non static ,not overload
        //Department/MEthod1
        [HttpGet]
        public IActionResult MEthod1()//acceptedd
        {
            return Content("M!");
        }
        [HttpPost]
        public IActionResult MEthod1(string name)//acceprter
        {
            return Content("M Overload");
        }
    }
}
