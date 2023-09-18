using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IInstitutionTypeRepository : IRepository
    {
        IQueryable<InstitutionTypeDto> GetInstitutionTypes(InstitutionTypeFilter filter);
    }
}
