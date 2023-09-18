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
    public class ContactTypeRepository : BaseRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }

        public IQueryable<ContactTypeDto> GetContactTypes(ContactTypeFilter filter)
        {
            return base.DbContext.ContactTypes.AsExpandable().Where(BuildWhereClause(filter)).Select(contactType =>
           new ContactTypeDto()
           {
               ContactTypeId = contactType.ContactTypeId,
               Label = contactType.Label
           });
        }

        private Expression<Func<ContactType, bool>> BuildWhereClause(ContactTypeFilter filter)
        {
            var predicate = PredicateBuilder.New<ContactType>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Label))
                    predicate = predicate.And(contactType => contactType.Label.ToLower().Contains(filter.Label.ToLower()));


                if (filter.ContactTypeId.HasValue)
                    predicate = predicate.And(contact => contact.ContactTypeId == filter.ContactTypeId.Value);

            }
            return predicate;
        }
    }
}