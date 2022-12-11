using FluentValidation;
using JwtSolution.Business.Abstract;
using JwtSolution.Business.Concrete;
using JwtSolution.Business.ValidationRules.FluentValidation;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.DataAccess.Concrete.EfCore.Repositories;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Dtos.ProductDtos;
using Microsoft.Extensions.DependencyInjection;

namespace JwtSolution.Business.DependencyResolver
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfCoreGenericRepository<>));

            services.AddScoped<IAppUserDal, EfCoreAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal, EfCoreAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<IAppRoleDal, EfCoreAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IProductDal, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();

            services.AddScoped<IJwtService, JwtManager>();
        }
    }
}
