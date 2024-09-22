using Application.Repositories;
using Infrastructure.DataReaders;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class InfrastructureServiceInstaller
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddSingleton<IDataReader, JsonDataReader>();

        return services;
    }
}
