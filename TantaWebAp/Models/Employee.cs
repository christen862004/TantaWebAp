using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TantaWebAp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int Salary { get; set; }
        public string? ImageURL { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
