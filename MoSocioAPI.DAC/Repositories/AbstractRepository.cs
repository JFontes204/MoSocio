using LinqKit;
using System.Data.Entity;
using System.Linq;

namespace MoSocioAPI.DAC.Repositories
{
    public abstract class AbstractRepository
    {
        protected MoSocioAPIDbContext DbContext { get; private set; }

        protected AbstractRepository(MoSocioAPIDbContext context)
        {
            this.DbContext = context;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return this.DbContext.Set<T>()
                .AsExpandable();
        }

        public virtual T GetById<T>(int id) where T : class
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public virtual void Add<T>(T entity) where T : class
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            this.DbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            this.DbContext.Set<T>().Remove(entity);
        }
    }
}
