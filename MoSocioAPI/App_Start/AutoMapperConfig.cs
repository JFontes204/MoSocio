using AutoMapper;
using MoSocioAPI.DTO;
using MoSocioAPI.Model;

namespace MoSocioAPI.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<SocioDto, Socio>();

            Mapper.CreateMap<CardDto, Card>();
            Mapper.CreateMap<Card, CardDto>();
            Mapper.CreateMap<QuotaDto, Quota>();
            Mapper.CreateMap<Quota, QuotaDto>();
            Mapper.CreateMap<Partner, PartnerDto>();
            Mapper.CreateMap<PartnerDto, Partner>();
            Mapper.CreateMap<ProvinceDto, Province>();
            Mapper.CreateMap<Province, ProvinceDto>();
            Mapper.CreateMap<QuotaTypeDto, QuotaType>();
            Mapper.CreateMap<QuotaType, QuotaTypeDto>();
            Mapper.CreateMap<InstitutionDto, Institution>();
            Mapper.CreateMap<Institution, InstitutionDto>();
            Mapper.CreateMap<PartnerTypeDto, PartnerType>();
            Mapper.CreateMap<PartnerType, PartnerTypeDto>();
            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>();
            Mapper.CreateMap<InstitutionTypeDto, InstitutionType>();
            Mapper.CreateMap<InstitutionType, InstitutionTypeDto>();
        }
    }
}