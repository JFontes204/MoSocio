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
    public class QuotaService : BaseService, IQuotaService
    {
        private IQuotaRepository quotaRepository;
        private IQuotaTypeRepository quotaTypeRepository;

        public QuotaService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.quotaRepository = this.UoW.Repository<IQuotaRepository>();
            this.quotaTypeRepository = this.UoW.Repository<IQuotaTypeRepository>();
        }
        public ResultCollectionDto<QuotaDto> GetQuotas(QuotaFilter filter)
        {

            IQueryable<QuotaDto> quota = this.quotaRepository.GetQuotas(filter);
            int count = quota.Count();
            filter.Records = count;

            return new ResultCollectionDto<QuotaDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? quota.ToList() : quota.OrderByDescending(q => q.QuotaId).Paginated(filter).ToList()
            };
        }
        public ResultCollectionDto<QuotaTypeDto> GetQuotaTypes(QuotaTypeFilter filter)
        {

            IQueryable<QuotaTypeDto> quotaType = this.quotaTypeRepository.GetQuotaTypes(filter);
            int count = quotaType.Count();
            filter.Records = count;

            return new ResultCollectionDto<QuotaTypeDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? quotaType.OrderBy(q => q.QuotaTypeId).ToList() : quotaType.OrderBy(q => q.QuotaTypeId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveQuota(QuotaDto dto)
        {
            bool result;

            Quota quota = Mapper.Map<Quota>(dto);

            if (quota.QuotaId == 0)
            {
                quota.DateCreation = DateTime.Now;
                this.quotaRepository.Add(quota);
            }
            else
            {
                this.quotaRepository.Update(quota);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = quota.QuotaId,
                Success = result
            };
        }
        public ServerResponseDto SaveQuotaType(QuotaTypeDto dto)
        {
            bool result;

            QuotaType quotaType = Mapper.Map<QuotaType>(dto);

            if (quotaType.QuotaTypeId == 0)
            {
                this.quotaTypeRepository.Add(quotaType);
            }
            else
            {
                this.quotaTypeRepository.Update(quotaType);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = quotaType.QuotaTypeId,
                Success = result
            };
        }
        public ServerResponseDto DeleteQuota(QuotaDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Quota quota = this.quotaRepository.GetById<Quota>(dto.QuotaId);
                if (quota != null)
                {
                    this.quotaRepository.Delete<Quota>(quota);
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
                Message = result ? "Quota elimanada com sucesso!" : "Não foi possível eliminar esta Quota"
            };
        }
        public ServerResponseDto DeleteQuotaType(QuotaTypeDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                QuotaType quotaType = this.quotaTypeRepository.GetById<QuotaType>(dto.QuotaTypeId);
                if (quotaType != null)
                {
                    this.quotaTypeRepository.Delete<QuotaType>(quotaType);
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
                Message = result ? "QuotaType elimanada com sucesso!" : "Não foi possível eliminar esta QuotaType"
            };
        }
    }
}
