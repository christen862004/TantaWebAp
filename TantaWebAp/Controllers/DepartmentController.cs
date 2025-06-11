using Microsoft.AspNetCore.Mvc;
using TantaWebAp.Models;

namespace TantaWebAp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> deptList= context.Departments.ToList();
            return View("Index",deptList);
        }
    }
}
