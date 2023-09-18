using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoSocioAPI.DAC.Security;
using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Services;

namespace MoSocioAPI.Services
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {
        ApplicationOAuthProvider oAuthProvider;
        ApplicationUserManager userManager;
        ApplicationRoleManager roleManager;

        public ApplicationUserService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.oAuthProvider = new ApplicationOAuthProvider("MoSocioWeb");
            this.userManager = new ApplicationUserManager(null);
            this.roleManager = new ApplicationRoleManager(null);
        }

        public ServerResponseDto SaveUser(ApplicationUserDto newUser)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                PasswordHash = newUser.PasswordHash,
                PhoneNumber = newUser.PhoneNumber
            };
            var obj = this.userManager.CreateAsync(user);
            if (obj != null)
            {
                return new ServerResponseDto() { 
                    Id = obj.Id,
                    Message = "Sucesso",
                    Object = obj,
                    StatusId = 1,
                    Success = true
                };
            }
            return new ServerResponseDto()
            {
                Id = 0,
                Message = "Erro",
                Object = null,
                StatusId = 0,
                Success = false
            };
        }

        public ResultCollectionDto<ApplicationUserDto> Authentication(string username, string password)
        {
            IQueryable<ApplicationUserDto> user = null;
            int count = user.Count();

            return new ResultCollectionDto<ApplicationUserDto>()
            {
                Count = count,
                CurrentPage = 1,
                PageCount = 1,
                RecordsPerPage = 6,
                Data = false ? user.OrderByDescending(u => u.Id).ToList() : user.OrderByDescending(u => u.Id)/*.Paginated()*/.ToList()
            };
        }
        public ResultCollectionDto<ApplicationUserDto> GetUsers(ApplicationUserFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
