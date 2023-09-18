using System.Data.Entity;

namespace MoSocioAPI.DAC.Repositories
{
    public abstract class BaseRepository<T> : AbstractRepository where T : class
    {
        protected DbSet<T> Set { get; private set; }

        protected BaseRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            this.Set = this.DbContext.Set<T>();
        }
    }
}
