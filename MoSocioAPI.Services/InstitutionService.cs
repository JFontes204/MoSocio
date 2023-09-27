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
    public class InstitutionService : BaseService, IInstitutionService
    {
        private IInstitutionRepository institutionRepository;
        private IInstitutionTypeRepository institutionTypeRepository;

        public InstitutionService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.institutionRepository = this.UoW.Repository<IInstitutionRepository>();
            this.institutionTypeRepository = this.UoW.Repository<IInstitutionTypeRepository>();
        }
        public ResultCollectionDto<InstitutionDto> GetInstitutions(InstitutionFilter filter)
        {
            IQueryable<InstitutionDto> institution = this.institutionRepository.GetInstitutions(filter);
            int count = institution.Count();
            filter.Records = count;

            return new ResultCollectionDto<InstitutionDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? institution.OrderBy(i => i.InstitutionId).ToList() : institution.OrderBy(i => i.InstitutionId).Paginated(filter).ToList()
            };
        }
        public ResultCollectionDto<InstitutionTypeDto> GetInstitutionTypes(InstitutionTypeFilter filter)
        {

            IQueryable<InstitutionTypeDto> institutionType = this.institutionTypeRepository.GetInstitutionTypes(filter);
            int count = institutionType.Count();
            filter.Records = count;

            return new ResultCollectionDto<InstitutionTypeDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? institutionType.OrderBy(i => i.InstitutionTypeId).ToList() : institutionType.OrderBy(i => i.InstitutionTypeId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveInstitution(InstitutionDto dto)
        {
            bool result = false;

            Institution institution = Mapper.Map<Institution>(dto);

            if (institution.InstitutionId == 0)
            {
                this.institutionRepository.Add(institution);
            }
            else
            {
                this.institutionRepository.Update(institution);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = institution.InstitutionId,
                Success = result
            };
        }
        public ServerResponseDto SaveInstitutionType(InstitutionTypeDto dto)
        {
            bool result;

            InstitutionType institutionType = Mapper.Map<InstitutionType>(dto);

            if (institutionType.InstitutionTypeId == 0)
            {
                this.institutionTypeRepository.Add(institutionType);
            }
            else
            {
                this.institutionTypeRepository.Update(institutionType);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = institutionType.InstitutionTypeId,
                Success = result
            };
        }
        public ServerResponseDto DeleteInstitution(InstitutionDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Institution institution = this.institutionRepository.GetById(dto.InstitutionId);
                if (institution != null)
                {
                    this.institutionRepository.Delete(institution);
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
                Message = result ? "Institution elimanada com sucesso!" : "Não foi possível eliminar esta Institution"
            };
        }
        public ServerResponseDto DeleteInstitutionType(InstitutionTypeDto dto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                InstitutionType institutionType = this.institutionTypeRepository.GetById(dto.InstitutionTypeId);
                if (institutionType != null)
                {
                    this.institutionTypeRepository.Delete(institutionType);
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
                Message = result ? "InstitutionType elimanada com sucesso!" : "Não foi possível eliminar esta InstitutionType"
            };
        }
    }
}
