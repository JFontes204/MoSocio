using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/oldusers")]
    public class ApplicationUserController : ApiController
    {
        private IApplicationUserService applicationUserService;
        public ApplicationUserController(/*IApplicationUserService applicationUserService*/)
        {
           // this.applicationUserService = applicationUserService;
        }

        [HttpGet, Route("getUsers")]
        public HttpResponseMessage GetUser([FromUri] ApplicationUserFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.applicationUserService.GetUsers(filter));
        }


        [HttpPost, Route("saveUser")]
        public HttpResponseMessage SaveUser(ApplicationUserDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.applicationUserService.SaveUser(dto));
        }

        [HttpPost, Route("auth")]
        public HttpResponseMessage Authentication(ApplicationUserDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.applicationUserService.Authentication(dto.UserName, dto.PasswordHash));
        }
    }
}
