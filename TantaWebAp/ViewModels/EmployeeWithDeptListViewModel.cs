using System.ComponentModel.DataAnnotations;
using TantaWebAp.Models;

namespace TantaWebAp.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Bussiness Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public int Salary { get; set; } 
        public string? ImageURL { get; set; }

        public int DepartmentId { get; set; }

        public List<Department>? DeptList { get; set; }
    }
}
