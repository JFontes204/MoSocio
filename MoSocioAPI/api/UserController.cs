using MoSocioAPI.DTO;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.api
{
    [RoutePrefix("api/users")]
    public class UserController: ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("createUser")]
        public HttpResponseMessage CreateUser([FromBody] UserDto userDto)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _service.SaveUser(userDto)); 
        }

        //Todo. 

        [HttpGet]
        [Route("teste")]
        public IHttpActionResult Get()
        {

            return Ok("Ola Deu Certo"); 
        }
    }
}
