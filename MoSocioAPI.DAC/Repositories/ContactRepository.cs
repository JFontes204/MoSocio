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
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(MoSocioAPIDbContext context)
            : base(context)
        {
        }

        public IQueryable<ContactDto> GetContacts(ContactFilter filter)
        {
            return base.DbContext.Contacts.AsExpandable().Where(BuildWhereClause(filter)).Select(contact =>
           new ContactDto()
           {
               ContactId = contact.ContactId,
               Label = contact.Label,
               ContactTypeId = contact.ContactTypeId,
               ContactType = contact.ContactType,
               PartnerId = contact.PartnerId,
               Partner = contact.Partner
           });
        }

        private Expression<Func<Contact, bool>> BuildWhereClause(ContactFilter filter)
        {
            var predicate = PredicateBuilder.New<Contact>(true);

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.Label))
                    predicate = predicate.And(contact => contact.Label.ToLower().Contains(filter.Label.ToLower()));

                if (filter.ContactId.HasValue)
                    predicate = predicate.And(contact => contact.ContactId == filter.ContactId.Value);

            }
            return predicate;
        }
    }
}
