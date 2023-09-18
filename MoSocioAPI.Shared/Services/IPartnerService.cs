using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface IPartnerService : IDisposable
    {
        ResultCollectionDto<PartnerDto> GetPartners(PartnerFilter filter);
        ResultCollectionDto<PartnerTypeDto> GetPartnerTypes(PartnerTypeFilter filter);
        ServerResponseDto SavePartner(PartnerDto partnerDto);
        ServerResponseDto SavePartnerType(PartnerTypeDto dto);
        ServerResponseDto DeletePartner(PartnerDto partnerDto);
        ServerResponseDto DeletePartnerType(PartnerTypeDto dto);
    }
}
