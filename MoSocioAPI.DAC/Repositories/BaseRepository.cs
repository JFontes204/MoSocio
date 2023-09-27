using MoSocioAPI.Shared.Repositories;
using System.Data.Entity;
using System.Linq;

namespace MoSocioAPI.DAC.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MoSocioAPIDbContext _context;
        private readonly DbSet<TEntity> _dbSet; 

        public BaseRepository(MoSocioAPIDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
           _dbSet.Add(entity); 
        }

        public IQueryable<TEntity> GetAll() 
            => _dbSet.AsQueryable<TEntity>().AsNoTracking();

        public TEntity GetById(int id)
        {
            TEntity entity = _dbSet.Find(id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
