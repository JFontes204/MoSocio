using AutoMapper;
using InvoicingPlan.Model;
using MoSocioAPI.DTO;
using MoSocioAPI.Model;

namespace MoSocioAPI.Api.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<SocioDto, Socio>();

            Mapper.CreateMap<CardDto, Card>().ReverseMap();
            Mapper.CreateMap<QuotaDto, Quota>().ReverseMap();
            Mapper.CreateMap<PartnerDto, Partner>().ReverseMap();
            Mapper.CreateMap<ProvinceDto, Province>().ReverseMap();
            Mapper.CreateMap<QuotaTypeDto, QuotaType>().ReverseMap();
            Mapper.CreateMap<InstitutionDto, Institution>().ReverseMap();
            Mapper.CreateMap<PartnerTypeDto, PartnerType>().ReverseMap();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
            Mapper.CreateMap<InstitutionTypeDto, InstitutionType>().ReverseMap();
            Mapper.CreateMap<UserDto, User>().ReverseMap(); 
        }
    }
}