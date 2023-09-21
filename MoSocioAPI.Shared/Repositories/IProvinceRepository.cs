using MoSocioAPI.DTO;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IProvinceRepository : IRepository
    {
        IQueryable<ProvinceDto> GetProvinces();
    }
}
