using Simu.Business.Interfaces;
using Simu.Business.Notificacoes;
using Simu.Business.Services;
using Simu.Data.Context;
using Simu.Data.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Simu.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static  IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Injetar dependência dos contextos
            services.AddScoped<SimuDbContext>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ITarefaService, TarefaService>();

            return services;
        }
    }
}
