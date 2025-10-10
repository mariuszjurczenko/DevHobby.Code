using DevHobby.Code.RPG.ConsoleApp;
using DevHobby.Code.RPG.Infrastructure.Extensions;
using Microsoft.Extensions.Hosting;

public class Program
{
    // Stała zamiast "magic string" - łatwo zmienić w jednym miejscu
    public const string CONFIG_FILE_NAME = "postacie.json";

    static async Task Main(string[] args)
    {
        // Tworzymy i konfigurujemy Host
        var host = CreateHostBuilder(args).Build();

        // Uruchamiamy aplikację
        var gameRunner = new GameRunner();
        await gameRunner.RunAsync(host);                 
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddRpgServices();
        });
}
