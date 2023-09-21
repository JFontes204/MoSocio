using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IQuotaRepository : IBaseRepository<Quota>
    {
        IQueryable<QuotaDto> GetQuotas(QuotaFilter filter);
    }
}
