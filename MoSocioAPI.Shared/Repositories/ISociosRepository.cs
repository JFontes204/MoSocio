using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface ISociosRepository : IBaseRepository<Socio>
    {
        IQueryable<SocioDto> GetSocios(SociosFilter filter);

    }
}
