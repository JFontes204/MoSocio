using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/addresss")]
    public class AddressController : ApiController
    {
        private IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet, Route("getAddress")]
        public HttpResponseMessage GetAddress([FromUri] AddressFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.addressService.GetAddresses(filter));
        }

        [HttpPost, Route("saveAddress")]
        public HttpResponseMessage SaveAddress(AddressDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.addressService.SaveAddress(dto));
        }

        [HttpDelete, Route("deleteAddress")]
        public HttpResponseMessage DeleteAddress(AddressDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.addressService.DeleteAddress(dto));
        }
    }
}
