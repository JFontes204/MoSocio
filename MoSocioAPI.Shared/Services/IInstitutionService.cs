using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface IInstitutionService : IDisposable
    {
        ResultCollectionDto<InstitutionDto> GetInstitutions(InstitutionFilter filter);
        ResultCollectionDto<InstitutionTypeDto> GetInstitutionTypes(InstitutionTypeFilter filter);
        ServerResponseDto SaveInstitution(InstitutionDto institutionDto);
        ServerResponseDto SaveInstitutionType(InstitutionTypeDto dto);
        ServerResponseDto DeleteInstitution(InstitutionDto institutionDto);
        ServerResponseDto DeleteInstitutionType(InstitutionTypeDto dto);
    }
}
