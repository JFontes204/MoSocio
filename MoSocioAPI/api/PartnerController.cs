using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/partners")]
    public class PartnerController : ApiController
    {
        private IPartnerService partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        [HttpGet, Route("getPartner")]
        public HttpResponseMessage GetPartner([FromUri] PartnerFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.GetPartners(filter));
        }
        [HttpGet, Route("getPartnerType")]
        public HttpResponseMessage GetPartnerType([FromUri] PartnerTypeFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.GetPartnerTypes(filter));
        }

        [HttpPost, Route("savePartner")]
        public HttpResponseMessage SavePartner(PartnerDto partnerDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.SavePartner(partnerDto));
        }
        [HttpPost, Route("savePartnerType")]
        public HttpResponseMessage SavePartnerType(PartnerTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.SavePartnerType(dto));
        }

        [HttpPost, Route("deletePartner")]
        public HttpResponseMessage DeletePartner(PartnerDto partnerDto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.DeletePartner(partnerDto));
        }
        [HttpPost, Route("deletePartnerType")]
        public HttpResponseMessage DeletePartnerType(PartnerTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.partnerService.DeletePartnerType(dto));
        }
    }
}
