using DevHobby.Code.RPG.Application.Interfaces;
using DevHobby.Code.RPG.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    static async Task Main(string[] args)
    {
        // Tworzymy i konfigurujemy Host
        var host = CreateHostBuilder(args).Build();

        // Uruchamiamy aplikację
        await RunGameAsync(host);                 
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddRpgServices();
        });

    private static async Task RunGameAsync(IHost host)
    {
        Console.WriteLine("Nacisnij Enter aby zobaczyć Bohaterów Gry");
        Console.ReadLine();
        Console.WriteLine("=== ARENA WALKI ===\n");

        try
        {
            // Tworzymy scope dla tej sesji gry
            using var serviceScope = host.Services.CreateScope();

            // DI Container automatycznie dostarcza wszystkie zależności
            var gameService = serviceScope.ServiceProvider.GetRequiredService<IGameService>();

            // Ładowanie postaci
            gameService.PobierzPostacie(("postacie.json"));

            // Podłączanie event handlerów
            foreach (var postac in gameService.Postacie)
                postac.KomunikatWygenerowany += Console.WriteLine;

            // Wyświetlanie statusów przed walką
            gameService.WyswietlStatusy();

            Console.WriteLine("Nacisnij Enter aby rozpocząć Grę");
            Console.ReadLine();
            Console.WriteLine("\n--- WALKA ROZPOCZĘTA! ---");

            // Start walki
            var zwyciezca = gameService.Start();

            // Podsumowanie
            Console.WriteLine("\n=== WALKA ZAKOŃCZONA ===");
            gameService.WyswietlStatusy();

            if (zwyciezca != null)
                Console.WriteLine($"\n🏆 {zwyciezca.Imie} WYGRYWA!");
            else
                Console.WriteLine("\n 💥 Wszyscy polegli w walce!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Błąd: {ex.Message}");
        }
    }
}
