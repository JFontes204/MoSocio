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
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        private readonly MoSocioAPIDbContext _context;
        public PartnerRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<PartnerDto> GetPartners(PartnerFilter filter)
        {
            return _context.Partners.AsExpandable().Where(BuildWhereClause(filter)).Select(partner =>
           new PartnerDto()
           {
               PartnerId = partner.PartnerId,
               Name = partner.Name,
               Birthday = partner.Birthday,
               PartnerNumber = partner.PartnerNumber,
               DocNumber = partner.DocNumber,
               Photo = partner.Photo,
               DateRegistration = partner.DateRegistration,
               Email = partner.Email,
               Telefone1 = partner.Telefone1,
               Telefone2 = partner.Telefone2,
               WhatsApp = partner.WhatsApp,
               Province = partner.Province,
               HomeAddress = partner.HomeAddress,
               ProvinceId = partner.ProvinceId,
               PartnerTypeId = partner.PartnerTypeId,
               PartnerType = partner.PartnerType,
               InstitutionId = partner.InstitutionId,
               Institution = partner.Institution,
               /* 
                Cards = partner.Cards,
                Quotas = partner.Quotas,
               */
           });
        }

        private Expression<Func<Partner, bool>> BuildWhereClause(PartnerFilter filter)
        {
            var predicate = PredicateBuilder.New<Partner>(true);

            if (filter != null)
            {
                if (filter.Institution == null)
                {
                    filter.Institution = new Institution();
                }
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    predicate = predicate.Or(partner => partner.Name.ToLower().Contains(filter.Name.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(filter.DocNumber))
                {
                    predicate = predicate.Or(partner => partner.DocNumber.ToLower().Contains(filter.DocNumber.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(filter.Telefone))
                {
                    predicate = predicate.Or(partner => partner.Telefone1.ToLower().Contains(filter.Telefone.ToLower()))
                        .Or(partner => partner.Telefone2.ToLower().Contains(filter.Telefone.ToLower()));
                }

                if (filter.Institution.InstitutionId != 0)
                {
                    predicate = predicate.And(partner => partner.InstitutionId == filter.Institution.InstitutionId);
                }

                if (filter.PartnerId.HasValue)
                {
                    predicate = predicate.And(partner => partner.PartnerId == filter.PartnerId.Value);
                }

            }
            return predicate;
        }
    }
}
