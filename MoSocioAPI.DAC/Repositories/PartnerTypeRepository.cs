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
    public class PartnerTypeRepository : BaseRepository<PartnerType>, IPartnerTypeRepository
    {
        public PartnerTypeRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }

        public IQueryable<PartnerTypeDto> GetPartnerTypes(PartnerTypeFilter filter)
        {
            return base.DbContext.PartnerTypes.AsExpandable().Where(BuildWhereClause(filter)).Select(partnerType =>
           new PartnerTypeDto()
           {
               PartnerTypeId = partnerType.PartnerTypeId,
               Label = partnerType.Label,
               Institution = partnerType.Institution,
               InstitutionId = partnerType.InstitutionId
           });
        }

        private Expression<Func<PartnerType, bool>> BuildWhereClause(PartnerTypeFilter filter)
        {
            var predicate = PredicateBuilder.New<PartnerType>(true);

            if (filter != null)
            {
                if (filter.Institution == null)
                {
                    filter.Institution = new Institution();
                }
                if (!string.IsNullOrWhiteSpace(filter.Label))
                {
                    predicate = predicate.And(partnerType => partnerType.Label.ToLower().Contains(filter.Label.ToLower()));
                }

                if (filter.Institution.InstitutionId != 0)
                {
                    predicate = predicate.And(partnerType => partnerType.InstitutionId == filter.Institution.InstitutionId);
                }

                if (filter.PartnerTypeId.HasValue)
                {
                    predicate = predicate.And(partnerType => partnerType.PartnerTypeId == filter.PartnerTypeId.Value);
                }

            }
            return predicate;
        }
    }
}
