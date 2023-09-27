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
    public class QuotaRepository : BaseRepository<Quota>, IQuotaRepository
    {
        private readonly MoSocioAPIDbContext _context;
        public QuotaRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<QuotaDto> GetQuotas(QuotaFilter filter)
        {
            return _context.Quotas.AsExpandable().Where(BuildWhereClause(filter)).Select(quota =>
           new QuotaDto()
           {
               QuotaId = quota.QuotaId,
               Value = quota.Value,
               DateCreation = quota.DateCreation,
               QuotaTypeId = quota.QuotaTypeId,
               QuotaType = quota.QuotaType,
               PartnerId = quota.PartnerId,
               Partner = quota.Partner,
               InstitutionId = quota.InstitutionId,
               Institution = quota.Institution
           });
        }

        private Expression<Func<Quota, bool>> BuildWhereClause(QuotaFilter filter)
        {
            var predicate = PredicateBuilder.New<Quota>(true);

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
                if (!string.IsNullOrWhiteSpace(filter.Value))
                {
                    predicate = predicate.And(quota => quota.Value.ToLower().Contains(filter.Value.ToLower()));
                }

                if (filter.Institution.InstitutionId != 0)
                {
                    predicate = predicate.And(quota => quota.InstitutionId == filter.Institution.InstitutionId);
                }
                if (filter.Partner.PartnerId != 0)
                {
                    predicate = predicate.And(quota => quota.PartnerId == filter.Partner.PartnerId);
                }

                if (filter.QuotaId.HasValue)
                {
                    predicate = predicate.And(quota => quota.QuotaId == filter.QuotaId.Value);
                }

            }
            return predicate;
        }
    }
}
