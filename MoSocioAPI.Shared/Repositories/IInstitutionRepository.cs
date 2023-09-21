using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IInstitutionRepository : IBaseRepository<Institution>
    {
        IQueryable<InstitutionDto> GetInstitutions(InstitutionFilter filter);
    }
}
