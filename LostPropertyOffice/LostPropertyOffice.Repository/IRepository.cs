using LostPropertyOffice.DataAccess.Entities;

namespace LostPropertyOffice.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T? GetById(int id);
        T? GetById(Guid id);
        T Save(T entity);
        void Delete(T entity);
    }
}