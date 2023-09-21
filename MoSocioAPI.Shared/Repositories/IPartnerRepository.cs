using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IPartnerRepository : IBaseRepository<Partner>
    {
        IQueryable<PartnerDto> GetPartners(PartnerFilter filter);
    }
}
