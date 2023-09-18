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
    public class AddressService : BaseService, IAddressService
    {
        private IAddressRepository addressRepository;

        public AddressService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.addressRepository = this.UoW.Repository<IAddressRepository>();
        }
        public ResultCollectionDto<AddressDto> GetAddresses(AddressFilter filter)
        {

            IQueryable<AddressDto> address = this.addressRepository.GetAddresses(filter);

            return new ResultCollectionDto<AddressDto>
            {
                Count = address.Count(),
                Data = filter.All ? address.OrderByDescending(a => a.AddressId).ToList() : address.OrderByDescending(a => a.AddressId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveAddress(AddressDto addressDto)
        {
            bool result;

            Address address = Mapper.Map<Address>(addressDto);

            if (address.AddressId == 0)
            {
                this.addressRepository.Add(address);
            }
            else
            {
                this.addressRepository.Update(address);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = address.AddressId,
                Success = result
            };
        }
        public ServerResponseDto SaveAddressInstitution(AddressDto addressDto)
        {
            bool result;

            AddressInstitution address = Mapper.Map<AddressInstitution>(addressDto);

            if (address.AddressId == 0)
            {
                this.addressRepository.Add(address);
            }
            else
            {
                this.addressRepository.Update(address);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = address.AddressId,
                Success = result
            };
        }
        public ServerResponseDto DeleteAddress(AddressDto addressDto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Address address = this.addressRepository.GetById<Address>(addressDto.AddressId);
                if(address != null)
                {
                    this.addressRepository.Delete<Address>(address);
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
                Message = result ? "Address elimanada com sucesso!" : "Não foi possível eliminar esta Address"
            };
        }
    }
}
