using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface ISociosService : IDisposable
    {
        ResultCollectionDto<SocioDto> GetSocios(SociosFilter filter);
        ServerResponseDto SaveSocio(SocioDto socioDto);
        ServerResponseDto DeleteSocio(SocioDto socioDto);
    }
}
