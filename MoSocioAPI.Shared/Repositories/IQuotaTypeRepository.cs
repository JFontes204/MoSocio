using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IQuotaTypeRepository : IRepository
    {
        IQueryable<QuotaTypeDto> GetQuotaTypes(QuotaTypeFilter filter);
    }
}
