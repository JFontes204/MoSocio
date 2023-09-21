using MoSocioAPI.DTO;
using System;
using System.Collections.Generic;

namespace MoSocioAPI.Shared.Services
{
    public interface IUserService : IDisposable
    {
        IEnumerable<UserDto> GetAllUSers();
        UserDto GetUserById(int id);
        UserDto GetuserByLogin(string userName, string password); 
        ServerResponseDto SaveUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(int id);

    }
}
