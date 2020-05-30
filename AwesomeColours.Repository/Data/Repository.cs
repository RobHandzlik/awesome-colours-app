using System;
using System.Linq;
using AwesomeColours.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeColours.Repository.Data
{
    public class Repository<T> : IRepository<T> where T : BaseAuditClass
    {
        private readonly ColoursDBContext _context;
        private DbSet<T> entities;

        public Repository(ColoursDBContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> Get(int id)
        {
            return entities.Where(p => p.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
