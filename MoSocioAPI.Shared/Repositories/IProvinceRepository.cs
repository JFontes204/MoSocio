using MoSocioAPI.DTO;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        IQueryable<ProvinceDto> GetProvinces();
    }
}
