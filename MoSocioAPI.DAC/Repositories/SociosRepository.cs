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
    public class SociosRepository : BaseRepository<Socio>, ISociosRepository
    {
        private readonly MoSocioAPIDbContext _context;
        public SociosRepository(MoSocioAPIDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IQueryable<SocioDto> GetSocios(SociosFilter filter)
        {
            return _context.Socios.AsExpandable().Where(BuildWhereClause(filter)).Select(soc =>
           new SocioDto()
           {
               SocioId = soc.SocioId,
               NumeroSocio = soc.NumeroSocio,
               DataRegisto = soc.DataRegisto
           });
        }

        private Expression<Func<Socio, bool>> BuildWhereClause(SociosFilter filter)
        {
            var predicate = PredicateBuilder.New<Socio>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.NumeroSocio))
                    predicate = predicate.And(soc => soc.NumeroSocio.ToLower().Contains(filter.NumeroSocio.ToLower()));


                if (filter.SocioId.HasValue)
                    predicate = predicate.And(soc => soc.SocioId == filter.SocioId.Value);

            }
            return predicate;
        }
    }
}
