using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Dapper
{
    public static class DapperHelperExtensions
    {
        public static IServiceCollection AddDapperHelper<TConnection>(this IServiceCollection services,
            IConfiguration config) where TConnection : IDbConnection, new()
        {
            services.AddOptions<DapperHelperOptions>()
                .Configure(config.Bind)
                .ValidateDataAnnotations();

            services.AddSingleton<IDapperHelper, DapperHelper<TConnection>>();
            return services;
        }
    }
}