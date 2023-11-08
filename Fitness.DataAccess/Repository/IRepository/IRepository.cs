using System.Linq.Expressions;


namespace Fitness.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Uebung
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllWithFilter(Expression<Func<T, bool>> filter);

        T Get(Expression<Func<T, bool>> filter);

        void Add (T item); 
        void Delete (T item);
        void DeleteRange(IEnumerable<T> items);
    }
}
