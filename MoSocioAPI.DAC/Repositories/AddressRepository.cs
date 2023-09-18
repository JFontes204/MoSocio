using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;
using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using MoSocioAPI.Shared.Repositories;
using System.Collections.Generic;

namespace MoSocioAPI.DAC.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }

        public IQueryable<AddressDto> GetAddresses(AddressFilter filter)
        {
            return base.DbContext.Addresses.AsExpandable().Where(BuildWhereClause(filter)).Select(address =>
           new AddressDto()
           {
               AddressId = address.AddressId,
               HomeAddress = address.HomeAddress,
               Neighborhood = address.Neighborhood,
               County = address.County,
               province = address.province,
               PartnerId = address.PartnerId,
               Partner = address.Partner
           });
        }

        private Expression<Func<Address, bool>> BuildWhereClause(AddressFilter filter)
        {
            var predicate = PredicateBuilder.New<Address>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Partner.Name))
                    predicate = predicate.And(address => address.Partner.Name.ToLower().Contains(filter.Partner.Name.ToLower()));

                if (filter.AddressId.HasValue)
                    predicate = predicate.And(address => address.AddressId == filter.AddressId.Value);

            }
            return predicate;
        }
    }
}
