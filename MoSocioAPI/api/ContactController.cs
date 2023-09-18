using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/contacts")]
    public class ContactController : ApiController
    {
        private IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet, Route("getContact")]
        public HttpResponseMessage GetContact([FromUri] ContactFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.GetContacts(filter));
        }

        [HttpPost, Route("saveContact")]
        public HttpResponseMessage SaveContact(ContactDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.SaveContact(dto));
        }

        [HttpDelete, Route("deleteContact")]
        public HttpResponseMessage DeleteContact(ContactDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.DeleteContact(dto));
        }
        [HttpGet, Route("getContactType")]
        public HttpResponseMessage GetContactType([FromUri] ContactTypeFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.GetContactTypes(filter));
        }

        [HttpPost, Route("saveContactType")]
        public HttpResponseMessage SaveContactType(ContactTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.SaveContactType(dto));
        }

        [HttpDelete, Route("deleteContactType")]
        public HttpResponseMessage DeleteContactType(ContactTypeDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.contactService.DeleteContactType(dto));
        }
    }
}
