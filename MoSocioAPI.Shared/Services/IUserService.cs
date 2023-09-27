using MoSocioAPI.DTO;
using System;
using System.Collections.Generic;

namespace MoSocioAPI.Shared.Services
{
    public interface IUserService : IDisposable
    {
        IEnumerable<UserDto> GetAllUSers();
        UserDto GetUserById(int id);
        UserDto GetuserByLogin(UserLoginDto login); 
        ServerResponseDto SaveUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        void DeleteUser(int id);

    }
}
