using System.Linq;

namespace restaurante.Repositories.Contracts{

    public interface IRepositoryBase<T>{
        
        T Get<TKey>(TKey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }

}