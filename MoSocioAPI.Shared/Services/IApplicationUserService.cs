using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoSocioAPI.Shared.Services
{
    public interface IApplicationUserService : IDisposable
    {
        ServerResponseDto SaveUser(ApplicationUserDto newUser);
        ResultCollectionDto<ApplicationUserDto> GetUsers(ApplicationUserFilter filter);
        ResultCollectionDto<ApplicationUserDto> Authentication(string username, string password);
    }
}
