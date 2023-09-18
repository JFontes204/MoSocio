using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Shared.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoSocioAPI.Api.api
{
    [RoutePrefix("api/cards")]
    public class CardController : ApiController
    {
        private ICardService cardService;

        public CardController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        [HttpGet, Route("getCard")]
        public HttpResponseMessage GetCard([FromUri] CardFilter filter)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.cardService.GetCards(filter));
        }

        [HttpPost, Route("saveCard")]
        public HttpResponseMessage SaveCard(CardDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.cardService.SaveCard(dto));
        }

        [HttpDelete, Route("deleteCard")]
        public HttpResponseMessage DeleteCard(CardDto dto)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.cardService.DeleteCard(dto));
        }
    }
}
