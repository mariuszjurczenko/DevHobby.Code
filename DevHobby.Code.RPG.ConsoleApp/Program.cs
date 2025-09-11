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
        
        // Tworzenie bohaterów
        var factory = new PostacFactory();
        var repostory = new JsonPostacRepository(factory);
        var battleService = new BattleService();
        battleService.KomunikatWygenerowany += Console.WriteLine;

        // Wczytanie z pliku konfiguracyjnego
        var wszystkiePostacie = repostory.PobierzPostacie("postacie.json");
        wszystkiePostacie.ForEach(p => p.KomunikatWygenerowany += Console.WriteLine);
         
        // Pokazujemy status przed walką
        wszystkiePostacie.ForEach(p => p.PokazStatus());
        
        Console.WriteLine("Nacisnij Enter aby rozpocząć Grę");
        Console.ReadLine();
        Console.WriteLine("\n--- WALKA ROZPOCZĘTA! ---");

        // CAŁA LOGIKA WALKI W JEDNEJ LINII!
        var zwyciezca = battleService.Sylumuj(wszystkiePostacie);

        // Podsumowanie
        Console.WriteLine("\n=== WALKA ZAKOŃCZONA ===");
        wszystkiePostacie.ForEach(p => p.PokazStatus());
             
        if (zwyciezca != null)
            Console.WriteLine($"\n🏆 {zwyciezca.Imie} WYGRYWA!");
        else
            Console.WriteLine("\n 💥 Wszyscy polegli w walce!");
    }
}
