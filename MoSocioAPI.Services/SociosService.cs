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
    public class SociosService : BaseService, ISociosService
    {
        private ISociosRepository sociosRepository;

        public SociosService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.sociosRepository = this.UoW.Repository<ISociosRepository>();
        }
        public ResultCollectionDto<SocioDto> GetSocios(SociosFilter filter)
        {

            IQueryable<SocioDto> socios = this.sociosRepository.GetSocios(filter);

            return new ResultCollectionDto<SocioDto>
            {
                Count = socios.Count(),
                Data = filter.All ? socios.OrderBy(soc => soc.DataRegisto).ToList() : socios.OrderBy(soc => soc.DataRegisto).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveSocio(SocioDto socioDto)
        {
            bool result;

            Socio socio = Mapper.Map<Socio>(socioDto);

            if (socio.SocioId == 0)
            {
                this.sociosRepository.Add(socio);
            }
            else
            {
                this.sociosRepository.Update(socio);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = socio.SocioId,
                Success = result
            };
        }
        public ServerResponseDto DeleteSocio(SocioDto socioDto)
        {
            bool result = false;
            int statusId;
            try
            {
                Socio socio = this.sociosRepository.GetById(socioDto.SocioId);
                this.sociosRepository.Delete(socio);
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
                Message = "Não é possível eliminar este Socio"
            };
        }
    }
}
