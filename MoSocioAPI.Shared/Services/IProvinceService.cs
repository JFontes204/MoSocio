using MoSocioAPI.DTO;
using MoSocioAPI.Model;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface IProvinceService : IDisposable
    {
        ResultCollectionDto<ProvinceDto> GetProvinces();
        ServerResponseDto SaveProvince(Province province);
        ServerResponseDto DeleteProvince(Province province);
    }
}
