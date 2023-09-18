using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/quotas")]
    public class QuotaController : ApiController
    {
        private IQuotaService quotaService;

        public QuotaController(IQuotaService quotaService)
        {
            this.quotaService = quotaService;
        }

        [HttpGet, Route("getQuota")]
        public HttpResponseMessage GetQuota([FromUri] QuotaFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.GetQuotas(filter));
        }

        [HttpPost, Route("saveQuota")]
        public HttpResponseMessage SaveQuota(QuotaDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.SaveQuota(dto));
        }

        [HttpPost, Route("deleteQuota")]
        public HttpResponseMessage DeleteQuota(QuotaDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.DeleteQuota(dto));
        }
        [HttpGet, Route("getQuotaType")]
        public HttpResponseMessage GetQuotaType([FromUri] QuotaTypeFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.GetQuotaTypes(filter));
        }

        [HttpPost, Route("saveQuotaType")]
        public HttpResponseMessage SaveQuotaType(QuotaTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.SaveQuotaType(dto));
        }

        [HttpPost, Route("deleteQuotaType")]
        public HttpResponseMessage DeleteQuotaType(QuotaTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.quotaService.DeleteQuotaType(dto));
        }
    }
}
