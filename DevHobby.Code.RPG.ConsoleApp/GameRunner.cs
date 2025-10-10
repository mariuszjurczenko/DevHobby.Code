using DevHobby.Code.RPG.Application.Interfaces;
using DevHobby.Code.RPG.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevHobby.Code.RPG.ConsoleApp;

public class GameRunner
{
    public async Task RunAsync(IHost host)
    {      
        try
        {
            // Tworzymy scope dla tej sesji gry
            using var serviceScope = host.Services.CreateScope();

            // DI Container automatycznie dostarcza wszystkie zależności
            var gameService = serviceScope.ServiceProvider.GetRequiredService<IGameService>();

            await RunGameAsync(gameService);
        }
        catch (FileNotFoundException ex)
        {
            DisplayError($"Nie znaleziono pliku: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            DisplayError($"Błąd konfiguracji: {ex.Message}");
        }
        catch (Exception ex)
        {
            DisplayError($"Nieoczekiwany Błąd: {ex.Message}");
        }
        finally
        {
            // Ten kod wykona się ZAWSZE - nawet jeśli wystąpił błąd
            WaitForExit();
        }
    }

    private async Task RunGameAsync(IGameService gameService)
    {
        WaitForUserInput("Nacisnij Enter aby zobaczyć Bohaterów Gry");
        DisplayWelcomeMessage();

        InitializeGame(gameService);
        SetupEventHandlers(gameService);
        DisplayGameStatus(gameService);

        WaitForUserInput("Nacisnij Enter aby rozpocząć Grę");
        var zwyciezca = StartBattle(gameService);
        DisplayResults(gameService, zwyciezca);
    }

    private void DisplayResults(IGameService gameService, Postac zwyciezca)
    {
        // Podsumowanie
        Console.WriteLine("\n=== WALKA ZAKOŃCZONA ===");
        gameService.WyswietlStatusy();

        if (zwyciezca != null)
            Console.WriteLine($"\n🏆 {zwyciezca.Imie} WYGRYWA!");
        else
            Console.WriteLine("\n 💥 Wszyscy polegli w walce!");
    }

    private Postac StartBattle(IGameService gameService)
    {
        Console.WriteLine("\n--- WALKA ROZPOCZĘTA! ---");

        // Start walki
        return gameService.Start();
    }

    private void DisplayGameStatus(IGameService gameService)
    {
        // Wyświetlanie statusów przed walką
        gameService.WyswietlStatusy();
    }

    private void SetupEventHandlers(IGameService gameService)
    {
        // Podłączanie event handlerów
        foreach (var postac in gameService.Postacie)
            postac.KomunikatWygenerowany += Console.WriteLine;
    }

    private void InitializeGame(IGameService gameService)
    {
        // Ładowanie postaci
        var configPath = GetConfigPath();
        gameService.PobierzPostacie(configPath);
    }

    private string GetConfigPath()
    {
        return Path.Combine(
           AppDomain.CurrentDomain.BaseDirectory,
           Program.CONFIG_FILE_NAME); 
    }

    private void DisplayWelcomeMessage()
    {
        Console.WriteLine("=== ARENA WALKI ===\n");
    }

    private void WaitForUserInput(string message)
    {
        Console.WriteLine(message);
        Console.ReadLine();
    }

    private void DisplayError(string message)
    {
        Console.WriteLine($"❌ {message}");
    }

    private void WaitForExit()
    {
        Console.WriteLine("\nNaciśnij dowolny klawisz aby zakończyć...");
        Console.ReadKey();
    }
}
