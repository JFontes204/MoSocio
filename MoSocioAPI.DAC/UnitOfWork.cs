using Microsoft.Practices.Unity;
using MoSocioAPI.Shared;
using System;

namespace MoSocioAPI.DAC
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUnityContainer container;
        private MoSocioAPIDbContext context;
        private bool disposed = false;

        public UnitOfWork(IUnityContainer container)
        {
            this.container = container;
            this.context = new MoSocioAPIDbContext();
        }

        public T Repository<T>() where T : class
        {
            return this.container.Resolve<T>(new ParameterOverride("context", this.context));
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
