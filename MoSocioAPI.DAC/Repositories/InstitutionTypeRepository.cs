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
    public class InstitutionTypeRepository : BaseRepository<InstitutionType>, IInstitutionTypeRepository
    {
        private readonly MoSocioAPIDbContext _context;

        public InstitutionTypeRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<InstitutionTypeDto> GetInstitutionTypes(InstitutionTypeFilter filter)
        {
            return _context.InstitutionTypes.AsExpandable().Where(BuildWhereClause(filter)).Select(institutionType =>
           new InstitutionTypeDto()
           {
               InstitutionTypeId = institutionType.InstitutionTypeId,
               Label = institutionType.Label
           });
        }

        private Expression<Func<InstitutionType, bool>> BuildWhereClause(InstitutionTypeFilter filter)
        {
            var predicate = PredicateBuilder.New<InstitutionType>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Label))
                {
                    predicate = predicate.And(institution => institution.Label.ToLower().Contains(filter.Label.ToLower()));
                }

                if (filter.InstitutionTypeId.HasValue)
                {
                    predicate = predicate.And(institutionType => institutionType.InstitutionTypeId == filter.InstitutionTypeId.Value);
                }

            }
            return predicate;
        }
    }
}
