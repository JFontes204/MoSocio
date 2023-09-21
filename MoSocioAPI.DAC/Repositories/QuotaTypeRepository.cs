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
  
    public class QuotaTypeRepository : BaseRepository<QuotaType>, IQuotaTypeRepository
    {
        private readonly MoSocioAPIDbContext _context;
        public QuotaTypeRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<QuotaTypeDto> GetQuotaTypes(QuotaTypeFilter filter)
        {
            return _context.QuotaTypes.AsExpandable().Where(BuildWhereClause(filter)).Select(quotaType =>
           new QuotaTypeDto()
           {
               QuotaTypeId = quotaType.QuotaTypeId,
               Label = quotaType.Label,
               InstitutionId = quotaType.InstitutionId,
               Institution = quotaType.Institution
           });
        }

        private Expression<Func<QuotaType, bool>> BuildWhereClause(QuotaTypeFilter filter)
        {
            var predicate = PredicateBuilder.New<QuotaType>(true);

            if (filter != null)
            {
                if (filter.Institution == null)
                {
                    filter.Institution = new Institution();
                }
                if (!string.IsNullOrWhiteSpace(filter.Label))
                {
                    predicate = predicate.And(quotaType => quotaType.Label.ToLower().Contains(filter.Label.ToLower()));
                }

                if (filter.Institution.InstitutionId != 0)
                {
                    predicate = predicate.And(quotaType => quotaType.InstitutionId == filter.Institution.InstitutionId);
                }

                if (filter.QuotaTypeId.HasValue)
                {
                    predicate = predicate.And(quotaType => quotaType.QuotaTypeId == filter.QuotaTypeId.Value);
                }

            }
            return predicate;
        }
    }
}
