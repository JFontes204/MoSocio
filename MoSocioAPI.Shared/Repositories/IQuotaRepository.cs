using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IQuotaRepository : IRepository
    {
        IQueryable<QuotaDto> GetQuotas(QuotaFilter filter);
    }
}
