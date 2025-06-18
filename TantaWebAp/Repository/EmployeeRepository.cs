using Microsoft.EntityFrameworkCore;
using TantaWebAp.Models;

namespace TantaWebAp.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository()
        {
            context=new ITIContext();
        }


        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee entity)
        {
           context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            Employee empFRomDb = GetById(id);
            context.Employees.Remove(empFRomDb);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Employee EmpFronDb=GetById(entity.Id);  
            EmpFronDb.Salary = entity.Salary;
            EmpFronDb.Name=entity.Name;
            EmpFronDb.Email=entity.Email;
            EmpFronDb.ImageURL=entity.ImageURL;
            EmpFronDb.DepartmentId=entity.DepartmentId;
        }
    }
}
