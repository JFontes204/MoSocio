using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IPartnerTypeRepository : IRepository
    {
        IQueryable<PartnerTypeDto> GetPartnerTypes(PartnerTypeFilter filter);
    }
}
