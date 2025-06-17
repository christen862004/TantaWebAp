using System.ComponentModel.DataAnnotations;

namespace TantaWebAp.Models
{
    public class UniqueAttribute:ValidationAttribute //Server Side Only (web api | Mvc)
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string Email = value.ToString();
            //data from Req
            Employee EmpFromReq = (Employee)validationContext.ObjectInstance;

            ITIContext context = new ITIContext();
            Employee EmpFromDB= context.Employees
                .FirstOrDefault(e=>e.Email== Email && e.DepartmentId==EmpFromReq.DepartmentId);
           
            if (EmpFromDB == null)
            {
                //valid
                return ValidationResult.Success;
            }
            //invalid
            return new ValidationResult("Email Already Exist :)");
        }
    }
}
