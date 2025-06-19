using TantaWebAp.Models;

namespace TantaWebAp.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        //Department CRUD :Create ,Read ,Update ,DElete
        ITIContext context;
        public DepartmentRepository(ITIContext _context)
        {
            context =_context;// new ITIContext();
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public void Add(Department department)
        {
            context.Departments.Add(department);
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Department entity)
        {
            //old ref
            Department deptFromDB = GetById(entity.Id);
            //set new value
            deptFromDB.Name= entity.Name;
            deptFromDB.ManagerName= entity.ManagerName;
        }

        public void Delete(int id)
        {
            Department depFRomDb=GetById(id);
            context.Departments.Remove(depFRomDb);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
