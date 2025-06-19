using Microsoft.EntityFrameworkCore;

namespace TantaWebAp.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
       
        public ITIContext(DbContextOptions<ITIContext> option) : base(option)//inject ==> Service Provider "REgister" 
        {

        }
        //public ITIContext() : base()
        //{
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TantaDB;Integrated Security=True;Encrypt=False");
        //}
        //DbContextOptions
        //1) DBMS "SqlServer"
        //2) Server Name : "."
        //3) Auth Type :Windows
        //4) Data Base NAme
    }
}
