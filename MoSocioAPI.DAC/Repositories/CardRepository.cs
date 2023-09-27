using LinqKit;
using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using MoSocioAPI.Shared.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoSocioAPI.DAC.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        private readonly MoSocioAPIDbContext _context;

        public CardRepository(MoSocioAPIDbContext context): base(context)
        {
            _context = context;
        }

        public IQueryable<CardDto> GetCards(CardFilter filter)
        {
            return _context.Cards.AsExpandable().Where(BuildWhereClause(filter)).Select(card =>
           new CardDto()
           {
               CardId = card.CardId,
               CardNumber = card.CardNumber,
               IsActived = card.IsActived,
               WasRaised = card.WasRaised,
               DateCreation = card.DateCreation,
               DateExpiration = card.DateExpiration,
               PartnerId = card.PartnerId,
               Partner = card.Partner,
               InstitutionId = card.InstitutionId,
               Institution = card.Institution
           });
        }

        public void Update<T>(T entity)
        {
            throw new NotImplementedException();
        }

        private Expression<Func<Card, bool>> BuildWhereClause(CardFilter filter)
        {
            var predicate = PredicateBuilder.New<Card>(true);

            if (filter != null)
            {
                if (filter.Institution == null)
                {
                    filter.Institution = new Institution();
                }
                if (filter.Partner == null)
                {
                    filter.Partner = new Partner();
                }
                if (!string.IsNullOrWhiteSpace(filter.CardNumber))
                {
                    predicate = predicate.And(card => card.CardNumber.ToLower().Contains(filter.CardNumber.ToLower()));
                }

                if (filter.Institution.InstitutionId != 0)
                {
                    predicate = predicate.And(card => card.InstitutionId == filter.Institution.InstitutionId);
                }

                if (filter.Partner.PartnerId != 0)
                {
                    predicate = predicate.And(card => card.PartnerId == filter.Partner.PartnerId);
                }

                if (filter.CardId.HasValue)
                {
                    predicate = predicate.And(card => card.CardId == filter.CardId.Value);
                }

            }
            return predicate;
        }
    }
}
