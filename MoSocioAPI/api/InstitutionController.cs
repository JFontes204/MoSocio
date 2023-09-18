using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/institutions")]
    public class InstitutionController : ApiController
    {
        private IInstitutionService institutionService;
        private IProvinceService proviceService;

        public InstitutionController(IInstitutionService institutionService, IProvinceService proviceService)
        {
            this.proviceService = proviceService;
            this.institutionService = institutionService;
        }

        [HttpGet, Route("getInstitution")]
        public HttpResponseMessage GetInstitution([FromUri] InstitutionFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.GetInstitutions(filter));
        }

        [HttpPost, Route("saveInstitution")]
        public HttpResponseMessage SaveInstitution(InstitutionDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.SaveInstitution(dto));
        }

        [HttpPost, Route("deleteInstitution")]
        public HttpResponseMessage DeleteInstitution(InstitutionDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.DeleteInstitution(dto));
        }
        [HttpGet, Route("getInstitutionType")]
        public HttpResponseMessage GetInstitutionType([FromUri] InstitutionTypeFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.GetInstitutionTypes(filter));
        }

        [HttpPost, Route("saveInstitutionType")]
        public HttpResponseMessage SaveInstitutionType(InstitutionTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.SaveInstitutionType(dto));
        }

        [HttpPost, Route("deleteInstitutionType")]
        public HttpResponseMessage DeleteInstitutionType(InstitutionTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.institutionService.DeleteInstitutionType(dto));
        }

        [HttpGet, Route("getProvince")]
        public HttpResponseMessage GetProvince()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.proviceService.GetProvinces());
        }
    }
}
