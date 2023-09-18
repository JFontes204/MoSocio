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
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }

        public IQueryable<InstitutionDto> GetInstitutions(InstitutionFilter filter)
        {
            return base.DbContext.Institutions.AsExpandable().Where(BuildWhereClause(filter)).Select(institution =>
           new InstitutionDto()
           {
               InstitutionId = institution.InstitutionId,
               Name = institution.Name,
               InstitutionTypeId = institution.InstitutionTypeId,
               InstitutionType = institution.InstitutionType,
               Email = institution.Email,
               HomeAddress = institution.HomeAddress,
               Province = institution.Province,
               ProvinceId = institution.ProvinceId,
               Telefone1 = institution.Telefone1,
               Telefone2 = institution.Telefone2,
               WhatsApp = institution.WhatsApp,
               /*   Partners = institution.Partners.Select(p => new Partner {
                       PartnerId = p.PartnerId,
                       Name = p.Name,
                       Birthday = p.Birthday,
                       DateRegistration = p.DateRegistration,
                       DocNumber = p.DocNumber,
                       PartnerNumber = p.PartnerNumber,
                       PartnerType = p.PartnerType,
                       PartnerTypeId = p.PartnerTypeId,
                       Photo = p.Photo
                  }).ToArray(),
                  Cards = institution.Cards.ToArray(),
                  Quotas = institution.Quotas.ToArray(), */
               //Addresses = institution.Addresses,
               //  Contacts = institution.Contacts
           });
        }

        private Expression<Func<Institution, bool>> BuildWhereClause(InstitutionFilter filter)
        {
            var predicate = PredicateBuilder.New<Institution>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    predicate = predicate.And(institution => institution.Name.ToLower().Contains(filter.Name.ToLower()));
                }

                if (filter.InstitutionId.HasValue)
                {
                    predicate = predicate.And(institution => institution.InstitutionId == filter.InstitutionId.Value);
                }

            }
            return predicate;
        }
    }
}
