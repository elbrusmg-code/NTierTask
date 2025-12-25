namespace EcommerceDataAccessLayer.Repositories.Contract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
    }
}
