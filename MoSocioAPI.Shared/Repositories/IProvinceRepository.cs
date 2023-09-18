using MoSocioAPI.DTO;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IProvinceRepository : IRepository
    {
        IQueryable<ProvinceDto> GetProvinces();
    }
}
