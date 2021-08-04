using MediatR;
using MediatRImplementationSample.Domain.Catalog.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatRImplementationSample.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.MeasureTime<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.ValidateCommand<,>));

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductRepositoryWrite), typeof(Repositories.Catalog.ProductWriteRepository));
            services.AddSingleton(typeof(IProductRepositoryReadOnly), typeof(Repositories.Catalog.ProductReadOnlyRepository));
        }

    }
}
