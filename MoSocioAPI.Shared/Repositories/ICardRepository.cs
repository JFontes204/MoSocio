using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        IQueryable<CardDto> GetCards(CardFilter filter);
    }
}
