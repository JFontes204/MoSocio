using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IInstitutionRepository : IRepository
    {
        IQueryable<InstitutionDto> GetInstitutions(InstitutionFilter filter);
    }
}
