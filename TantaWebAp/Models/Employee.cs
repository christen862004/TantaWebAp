using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TantaWebAp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Required")]
        [MinLength(3,ErrorMessage ="Name Must be more than 2 letter")]
        [MaxLength(25)]
        public string Name { get; set; }

        //[RegularExpression(@"\w+@gmail\.com")]//christen@gmail.com
        [Unique]
        public string? Email { get; set; }

        //[Range(7000,50000)]
        //[GreaterThan(Number =5000)]
        
        [Remote("CheckSalary","Employee",AdditionalFields = "Name")]//Employee/CheckSalary?Salary=10000&Name=Manar
        public int Salary { get; set; }

        [RegularExpression(@"\w+\.(png|jpg)",ErrorMessage ="Image Must be png Or Jpg")]//default
        public string? ImageURL { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        
        //[Required]
        public Department? Department { get; set; }
    }
}
