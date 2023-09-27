using MoSocioAPI.DTO;
using MoSocioAPI.Model;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Repositories;
using MoSocioAPI.Shared.Services;
using System;
using System.Linq;

namespace MoSocioAPI.Services
{
    public class ProvinceService : BaseService, IProvinceService
    {
        private IProvinceRepository provinceRepository;
        public ProvinceService(IUnitOfWork uoW)
           : base(uoW)
        {
            this.provinceRepository = this.UoW.Repository<IProvinceRepository>();
        }

        public ResultCollectionDto<ProvinceDto> GetProvinces()
        {
            IQueryable<ProvinceDto> province = this.provinceRepository.GetProvinces();

            return new ResultCollectionDto<ProvinceDto>
            {
                Count = province.Count(),
                Data = province.ToList()
            };
        }

        public ServerResponseDto SaveProvince(Province province)
        {
            bool result;

            if (province.ProvinceId == 0)
            {
                this.provinceRepository.Add(province);
            }
            else
            {
                this.provinceRepository.Update(province);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = province.ProvinceId,
                Success = result
            };
        }

        public ServerResponseDto DeleteProvince(Province model)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Province province = this.provinceRepository.GetById(model.ProvinceId);
                if (province != null)
                {
                    this.provinceRepository.Delete(province);
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
                Message = result ? "Provincia elimanada com sucesso!" : "Não foi possível eliminar esta provincia"
            };
        }
    }
}
