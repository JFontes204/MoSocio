using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface ISociosRepository : IRepository
    {
        IQueryable<SocioDto> GetSocios(SociosFilter filter);

    }
}
