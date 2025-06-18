namespace TantaWebAp.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();// string includes="");
        //List<T> GetAll(string includes="");
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
