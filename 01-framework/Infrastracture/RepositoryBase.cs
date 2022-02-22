
using _01_framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _01_framework.Infrastracture
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void Savechanges()
        {
            _context.SaveChanges();
        }
    }
}
