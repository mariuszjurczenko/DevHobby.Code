using DevHobby.Code.RPG;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Nacisnij Enter aby zobaczyć Bohaterów Gry");
        Console.ReadLine();
        Console.WriteLine("=== ARENA WALK ===\n");
        
        // Tworzenie bohaterów
        var rycerz = new Wojownik("Sir Galahad");
        var czarnoksieznik = new Mag("Mroczny Mag");
        var lucznik = new Lucznik("Legolas");

        var ork = new Ork();
        var smok = new Smok();
        var goblin = new Goblin();
   
        // Lista wszystkich postaci biorących udział w walce
        var wszystkiePostacie = new List<Postac> { rycerz, czarnoksieznik, lucznik, ork, goblin, smok };

        // Pokazujemy status przed walką
        wszystkiePostacie.ForEach(p => p.PokazStatus());
        
        Console.WriteLine("Nacisnij Enter aby rozpocząć Grę");
        Console.ReadLine();
        Console.WriteLine("\n--- WALKA ROZPOCZĘTA! ---");
        var random = new Random();
        
        // Symulacja walki
        while (wszystkiePostacie.Count(p => p.PunktyZycia > 0) > 1)
        {
            // Losowanie atakującego spośród żywych postaci
            var zywePostacie = wszystkiePostacie.Where(p => p.PunktyZycia > 0).ToList();
            if (zywePostacie.Count <= 1) break;

            var atakujacy = zywePostacie[random.Next(zywePostacie.Count)];

            // Losowanie celu (różnego od atakującego)
            Postac cel;
            do
            {
                cel = zywePostacie[random.Next(zywePostacie.Count)];
            } while (cel == atakujacy);

            // Wykonanie ataku
            atakujacy.Atakuj(cel);

            // Krótka pauza, aby śledzić przebieg walki
            Thread.Sleep(1000);

            // Kontratak
            if (cel.PunktyZycia > 0)
            {
                cel.Atakuj(atakujacy);
            }

            // Czasem boharter się leczy
            if (atakujacy is Bohater bohater && atakujacy.PunktyZycia < 10 && atakujacy.PunktyZycia > 0)
            {
                Console.WriteLine($"\n{atakujacy.Imie} używa mikstury!");
                bohater.Lecz(30);
            }

            Thread.Sleep(1000); // Pauza dla dramatyzmu
        }
        
        // Podsumowanie
        Console.WriteLine("\n=== WALKA ZAKOŃCZONA ===");
        wszystkiePostacie.ForEach(p => p.PokazStatus());
        
        // Zakończenie gry i ogłoszenie zwycięzcy
        var zwyciezca = wszystkiePostacie.FirstOrDefault(p => p. PunktyZycia > 0);

        if (zwyciezca != null)
            Console.WriteLine($"\n🏆 {zwyciezca.Imie} WYGRYWA!");
        else
            Console.WriteLine("\n 💥 Wszyscy polegli w walce!");
    }
}
