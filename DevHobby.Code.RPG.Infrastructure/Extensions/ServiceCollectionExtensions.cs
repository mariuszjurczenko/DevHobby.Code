using DevHobby.Code.RPG.Application;
using DevHobby.Code.RPG.Application.Interfaces;
using DevHobby.Code.RPG.Core.Interfaces;
using DevHobby.Code.RPG.Core.Services;
using DevHobby.Code.RPG.Infrastructure.Data;
using DevHobby.Code.RPG.Infrastructure.FileSystem;
using DevHobby.Code.RPG.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DevHobby.Code.RPG.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRpgServices(this IServiceCollection services)
    {
        // Core Services
        services.AddTransient<IBattleService, BattleService>();

        // Application Services
        services.AddScoped<IGameService, GameService>();

        // Infrastructure Services
        services.AddSingleton<IPostacFactory, PostacFactory>();
        services.AddTransient<IPostacRepository, JsonPostacRepository>();
        services.AddScoped<IFileReader, FileReader>();

        return services;
    }
}
