
using System.Linq.Expressions;


namespace _01_framework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        void Create(T entity);
        T GetBy(TKey id);
        List<T> Get();
        void Savechanges();
        bool IsExist(Expression<Func<T, bool>> expression);

    }
}
