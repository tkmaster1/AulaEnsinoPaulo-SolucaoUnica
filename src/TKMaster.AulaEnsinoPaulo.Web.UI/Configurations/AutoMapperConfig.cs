using Microsoft.Extensions.DependencyInjection;
using System;
using TKMaster.SolucaoUnica.Web.UI.AutoMapper;

namespace TKMaster.SolucaoUnica.Web.UI.Configurations
{
    /// <summary>
    /// 4º passo, criação das classes de mapeamento
    /// </summary>
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
