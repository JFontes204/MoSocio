using System;

namespace MoSocioAPI.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        T Repository<T>() where T : class;
        int SaveChanges();
    }
}
