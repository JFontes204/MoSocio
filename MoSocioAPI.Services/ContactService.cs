using AutoMapper;
using MoSocioAPI.DAC;
using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Repositories;
using MoSocioAPI.Shared.Services;
using System;
using System.Linq;

namespace MoSocioAPI.Services
{
    public class ContactService : BaseService, IContactService
    {
        private IContactRepository contactRepository;
        private IContactTypeRepository contactTypeRepository;

        public ContactService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.contactRepository = this.UoW.Repository<IContactRepository>();
            this.contactTypeRepository = this.UoW.Repository<IContactTypeRepository>();
        }
        public ResultCollectionDto<ContactDto> GetContacts(ContactFilter filter)
        {

            IQueryable<ContactDto> contact = this.contactRepository.GetContacts(filter);

            return new ResultCollectionDto<ContactDto>
            {
                Count = contact.Count(),
                Data = filter.All ? contact.OrderByDescending(c => c.ContactId).ToList() : contact.OrderByDescending(c => c.ContactId).Paginated(filter).ToList()
            };
        }
        public ResultCollectionDto<ContactTypeDto> GetContactTypes(ContactTypeFilter filter)
        {

            IQueryable<ContactTypeDto> contactType = this.contactTypeRepository.GetContactTypes(filter);

            return new ResultCollectionDto<ContactTypeDto>
            {
                Count = contactType.Count(),
                Data = filter.All ? contactType.OrderBy(c => c.ContactTypeId).ToList() : contactType.OrderBy(c => c.ContactTypeId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveContact(ContactDto dto)
        {
            bool result;

            Contact contact = Mapper.Map<Contact>(dto);

            if (contact.ContactId == 0)
            {
                this.contactRepository.Add(contact);
            }
            else
            {
                this.contactRepository.Update(contact);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = contact.ContactId,
                Success = result
            };
        }
        public ServerResponseDto SaveContactInstitution(ContactDto dto)
        {
            bool result;

            ContactInstitution contact = Mapper.Map<ContactInstitution>(dto);

            if (contact.ContactId == 0)
            {
                this.contactRepository.Add(contact);
            }
            else
            {
                this.contactRepository.Update(contact);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = contact.ContactId,
                Success = result
            };
        }
        public ServerResponseDto SaveContactType(ContactTypeDto dto)
        {
            bool result;

            ContactType contactType = Mapper.Map<ContactType>(dto);

            if (contactType.ContactTypeId == 0)
            {
                this.contactTypeRepository.Add(contactType);
            }
            else
            {
                this.contactTypeRepository.Update(contactType);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = contactType.ContactTypeId,
                Success = result
            };
        }
        public ServerResponseDto DeleteContact(ContactDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Contact contact = this.contactRepository.GetById<Contact>(dto.ContactId);
                if(contact != null)
                {
                    this.contactRepository.Delete<Contact>(contact);
                }
                result = this.UoW.SaveChanges() != 0;
                statusId = 1;
            }
            catch (Exception ex)
            {
                statusId = 2;
                Console.WriteLine(ex.Message);
            }

            return new ServerResponseDto
            {
                Success = result,
                StatusId = statusId,
                Message = result ? "Contact elimanada com sucesso!" : "Não foi possível eliminar esta Contact"
            };
        }
        public ServerResponseDto DeleteContactType(ContactTypeDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                ContactType contactType = this.contactTypeRepository.GetById<ContactType>(dto.ContactTypeId);
                if (contactType != null)
                {
                    this.contactTypeRepository.Delete<ContactType>(contactType);
                }
                result = this.UoW.SaveChanges() != 0;
                statusId = 1;
            }
            catch (Exception ex)
            {
                statusId = 2;
                Console.WriteLine(ex.Message);
            }

            return new ServerResponseDto
            {
                Success = result,
                StatusId = statusId,
                Message = result ? "ContactType elimanada com sucesso!" : "Não foi possível eliminar esta ContactType"
            };
        }
    }
}
