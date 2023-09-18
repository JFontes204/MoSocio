using LinqKit;
using MoSocioAPI.DTO;
using MoSocioAPI.Model;
using MoSocioAPI.Shared.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoSocioAPI.DAC.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }
        public IQueryable<ProvinceDto> GetProvinces()
        {
            return base.DbContext.Provinces.AsExpandable().Where(BuildWhereClause()).Select(province =>
            new ProvinceDto()
            {
                ProvinceId = province.ProvinceId,
                Name = province.Name,
            });
        }

        private Expression<Func<Province, bool>> BuildWhereClause()
        {
            var predicate = PredicateBuilder.New<Province>(true);

            predicate = predicate.And(p => p.ProvinceId != 0);

            return predicate;
        }
    }
}
