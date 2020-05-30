using System.Linq;
using AwesomeColours.DataAccess.Entities;

namespace AwesomeColours.Repository.Data
{
    public interface IRepository<T> where T : BaseAuditClass
    {
        IQueryable<T> Get(int id);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
