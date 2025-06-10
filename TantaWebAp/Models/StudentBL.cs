namespace TantaWebAp.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new() {
                new(){Id=1,Name="Ahmedd",ImageUrl="m.png"},
                new(){Id=2,Name="Sara",ImageUrl="2.jpg"},
                new(){Id=3,Name="Mohamed",ImageUrl="m.png"},
                new(){Id=4,Name="Fatma",ImageUrl="2.jpg"},
            };
        }

        public List<Student> GetAll() {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
