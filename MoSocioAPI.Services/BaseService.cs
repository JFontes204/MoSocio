using MoSocioAPI.Shared;
using System;

namespace MoSocioAPI.Services
{
    public abstract class BaseService : IDisposable
    {
        protected IUnitOfWork UoW { get; private set; }

        protected BaseService(IUnitOfWork uoW)
        {
            this.UoW = uoW;
        }

        public void Dispose()
        {
            this.UoW.Dispose();
        }
    }
}
