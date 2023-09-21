using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll() ;
        TEntity GetById(int id) ; 
        void Update(TEntity entity); 
        void Add(TEntity entity) ;
        void Delete(TEntity entity);
    }
}
