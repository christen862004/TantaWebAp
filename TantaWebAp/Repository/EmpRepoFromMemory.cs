using TantaWebAp.Models;

namespace TantaWebAp.Repository
{
    public class EmpRepoFromMemory : IEmployeeRepository
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return new List<Employee>
           { new Employee { Id = 1,Name="ahmed"},new Employee { Id = 2,Name="Sara"} };
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
