using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface IQuotaService : IDisposable
    {
        ResultCollectionDto<QuotaDto> GetQuotas(QuotaFilter filter);
        ResultCollectionDto<QuotaTypeDto> GetQuotaTypes(QuotaTypeFilter filter);
        ServerResponseDto SaveQuota(QuotaDto quotaDto);
        ServerResponseDto SaveQuotaType(QuotaTypeDto dto);
        ServerResponseDto DeleteQuota(QuotaDto quotaDto);
        ServerResponseDto DeleteQuotaType(QuotaTypeDto dto);
    }
}
