using DevHobby.Code.RPG.Application;
using DevHobby.Code.RPG.Core.Services;
using DevHobby.Code.RPG.Infrastructure;
using DevHobby.Code.RPG.Infrastructure.Data;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Nacisnij Enter aby zobaczyć Bohaterów Gry");
        Console.ReadLine();
        Console.WriteLine("=== ARENA WALKI ===\n");

        try
        {
            // Tworzenie bohaterów
            var factory = new PostacFactory();
            var repository = new JsonPostacRepository(factory);
            var battleService = new BattleService();
            battleService.KomunikatWygenerowany += Console.WriteLine;

            var gameService = new GameService(repository, battleService);

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
