using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IQuotaTypeRepository : IBaseRepository<QuotaType>
    {
        IQueryable<QuotaTypeDto> GetQuotaTypes(QuotaTypeFilter filter);
    }
}
