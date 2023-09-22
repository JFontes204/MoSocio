using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using MoSocioAPI.DAC;
using MoSocioAPI.DAC.Repositories;
using MoSocioAPI.Model;
using MoSocioAPI.Services;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Repositories;
using MoSocioAPI.Shared.Services;
using System;
using System.Web;

namespace MoSocioAPI.Api
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();

            RegisterTypes(container);
            return container;
        });

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(container));

            #region Repositories


            container.RegisterType<ISociosRepository, SociosRepository>();

            container.RegisterType<ICardRepository, CardRepository>();
            container.RegisterType<IQuotaRepository, QuotaRepository>();
            container.RegisterType<IPartnerRepository, PartnerRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IQuotaTypeRepository, QuotaTypeRepository>();
            container.RegisterType<IInstitutionRepository, InstitutionRepository>();
            container.RegisterType<IPartnerTypeRepository, PartnerTypeRepository>();
            container.RegisterType<IInstitutionTypeRepository, InstitutionTypeRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
           

            #endregion

            #region Services
            container.RegisterType<ISociosService, SociosService>();

            container.RegisterType<ICardService, CardService>();
            container.RegisterType<IQuotaService, QuotaService>();
            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IInstitutionService, InstitutionService>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType(typeof(IRoleStore<,>), typeof(RoleStore<IdentityRole>), new InjectionConstructor(typeof(MoSocioAPIDbContext)));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<ApplicationUser>), new InjectionConstructor(typeof(MoSocioAPIDbContext)));
            container.RegisterType<IAuthenticationManager>(new InjectionFactory((_) => HttpContext.Current.GetOwinContext().Authentication));
            #endregion
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
    }
}