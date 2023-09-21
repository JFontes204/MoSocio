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
    public class PartnerService : BaseService, IPartnerService
    {
        private IPartnerRepository partnerRepository;
        private IPartnerTypeRepository partnerTypeRepository;

        public PartnerService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.partnerRepository = this.UoW.Repository<IPartnerRepository>();
            this.partnerTypeRepository = this.UoW.Repository<IPartnerTypeRepository>();
        }
        public ResultCollectionDto<PartnerDto> GetPartners(PartnerFilter filter)
        {

            IQueryable<PartnerDto> partner = this.partnerRepository.GetPartners(filter);
            int count = partner.Count();
            filter.Records = count;

            return new ResultCollectionDto<PartnerDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? partner.OrderByDescending(p => p.PartnerId).ToList() : partner.OrderByDescending(p => p.PartnerId).Paginated(filter).ToList()
            };
        }
        public ResultCollectionDto<PartnerTypeDto> GetPartnerTypes(PartnerTypeFilter filter)
        {

            IQueryable<PartnerTypeDto> partnerType = this.partnerTypeRepository.GetPartnerTypes(filter);
            int count = partnerType.Count();
            filter.Records = count;

            return new ResultCollectionDto<PartnerTypeDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? partnerType.OrderBy(p => p.PartnerTypeId).ToList() : partnerType.OrderBy(p => p.PartnerTypeId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SavePartner(PartnerDto dto)
        {
            bool result = false;

            Partner partner = Mapper.Map<Partner>(dto);

            if (partner.PartnerId == 0)
            {
                partner.DateRegistration = DateTime.Now;
                this.partnerRepository.Add(partner);
            }
            else
            {
                this.partnerRepository.Update(partner);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = partner.PartnerId,
                Success = result
            };
        }
        public ServerResponseDto SavePartnerType(PartnerTypeDto dto)
        {
            bool result = false;

            PartnerType partnerType = Mapper.Map<PartnerType>(dto);

            if (partnerType.PartnerTypeId == 0)
            {
                this.partnerTypeRepository.Add(partnerType);
            }
            else
            {
                this.partnerTypeRepository.Update(partnerType);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = partnerType.PartnerTypeId,
                Success = result
            };
        }
        public ServerResponseDto DeletePartner(PartnerDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Partner partner = this.partnerRepository.GetById(dto.PartnerId);
                if (partner != null)
                {
                    this.partnerRepository.Delete(partner);
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
                Message = result ? "Partner elimanado com sucesso!" : "Não foi possível eliminar este Partner"
            };
        }
        public ServerResponseDto DeletePartnerType(PartnerTypeDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                PartnerType partnerType = this.partnerTypeRepository.GetById(dto.PartnerTypeId);
                if (partnerType != null)
                {
                    this.partnerTypeRepository.Delete(partnerType);
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
                Message = result ? "PartnerType elimanado com sucesso!" : "Não foi possível eliminar este PartnerType"
            };
        }
    }
}
