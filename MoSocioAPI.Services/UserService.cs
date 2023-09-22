﻿using AutoMapper;
using InvoicingPlan.Model;
using MoSocioAPI.DTO;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Repositories;
using MoSocioAPI.Shared.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MoSocioAPI.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _repository; 
        public UserService(IUnitOfWork uoW) : base(uoW)
        {
            _repository = uoW.Repository<IUserRepository>(); 
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetById(id);
            _repository.Delete(user); 
        }

        public IEnumerable<UserDto> GetAllUSers()
        {
            var usersEntity = _repository.GetAll().ToList();

            return Mapper.Map<IEnumerable<UserDto>>(usersEntity);
        }

        public UserDto GetUserById(int id)
        {
           var user = _repository.GetById(id);
            return Mapper.Map<UserDto>(user); 
        }

        public UserDto GetuserByLogin(UserLoginDto loginDto)
        {
            var passwordEncripted = EncryptPassword(loginDto.Password);
            var userEntity = _repository.GetUserByLogin(loginDto.UserName, passwordEncripted);

            return Mapper.Map<UserDto>(userEntity); 
        }

        public ServerResponseDto SaveUser(UserDto userDto)
        {
            bool result; 
            var userEntity = Mapper.Map<User>(userDto);
            userEntity.Password = EncryptPassword(userDto.Password);
            
            _repository.Add(userEntity);
            result = UoW.SaveChanges() != 0; 

            return new ServerResponseDto
            {
                Id = userDto.Id,
                Success = result
            }; 
        }

        public void UpdateUser(UserDto userDto)
        {
            var userEntity = Mapper.Map<User>(userDto); 
            _repository.Update(userEntity);
        }

        private string EncryptPassword(string password)
        {
            var md5 = MD5.Create();
            var code = Encoding.ASCII.GetBytes(password);
            var hash = md5.ComputeHash(code);

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}