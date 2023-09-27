using MoSocioAPI.DTO;
using MoSocioAPI.Services;
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
        private readonly TokenService _token; 

        public UserController(IUserService service, TokenService token)
        {
            _service = service;
            _token = token;
        }

        [HttpPost]
        [Route("createUser")]
        public HttpResponseMessage CreateUser([FromBody] UserDto userDto)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _service.SaveUser(userDto)); 
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLoginDto loginDto)
        {
            var userDto = _service.GetuserByLogin(loginDto);

            if (userDto is null)
                return BadRequest("user ou password Invalido");

            var token = _token.GeneratorToken(userDto); 

            return Ok(new
            {
                UserName = userDto.UserName,
                FullName = userDto.FullName,
                Phone = userDto.PhoneNumber,
                Email = userDto.Email,
                Token = token, 
                Roles = userDto.Roles,
            }); 
        }
        [HttpGet]
        [Route("users")]
        [Authorize(Roles ="admin")]
        public IHttpActionResult GetAll()
        {
           return Ok(_service.GetAllUSers()); 
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult GetById([FromUri] int id)
        {
            return Ok(_service.GetUserById(id));
        }
    }
}
