using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [Authorize, RoutePrefix("api/socios")]
    public class SociosController : ApiController
    {
        private ISociosService sociosService;

        public SociosController(ISociosService sociosService)
        {
            this.sociosService = sociosService;
        }

        [HttpGet, Route("getSocios")]
        public HttpResponseMessage GetSocios([FromUri] SociosFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.sociosService.GetSocios(filter));
        }

        [HttpPost, Route("saveSocio")]
        public HttpResponseMessage SaveSocio(SocioDto socioDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.sociosService.SaveSocio(socioDto));
        }

        [HttpPost, Route("deleteSocio")]
        public HttpResponseMessage DeleteSocio(SocioDto socioDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.sociosService.DeleteSocio(socioDto));
        }
    }
}
