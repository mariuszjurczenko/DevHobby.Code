using DevHobby.Code.RPG;

public class Program
{
    static void Main()
    {
        Console.WriteLine("=== ARENA WALK ===\n");
        
        // Tworzenie bohaterów
        Bohater rycerz = new Bohater("Sir Galahad", 100, 30);
        Bohater czarnoksieznik = new Bohater("Mroczny Mag", 80, 35);
        
        // Pokazujemy status przed walką
        rycerz.PokazStatus();
        czarnoksieznik.PokazStatus();
        
        Console.WriteLine("\n--- WALKA ROZPOCZĘTA! ---");
        
        // Symulacja walki
        while (rycerz.PunktyZycia > 0 && czarnoksieznik.PunktyZycia > 0)
        {
            rycerz.Atakuj(czarnoksieznik);
            
            if (czarnoksieznik.PunktyZycia > 0)
            {
                czarnoksieznik.Atakuj(rycerz);
            }
            
            // Czasem rycerz się leczy
            if (rycerz.PunktyZycia < 30 && rycerz.PunktyZycia > 0)
            {
                Console.WriteLine($"\n{rycerz.Imie} używa mikstury!");
                rycerz.Lecz(20);
            }
            
            Thread.Sleep(1000); // Pauza dla dramatyzmu
        }
        
        // Podsumowanie
        Console.WriteLine("\n=== WALKA ZAKOŃCZONA ===");
        rycerz.PokazStatus();
        czarnoksieznik.PokazStatus();
        
        if (rycerz.PunktyZycia > 0)
            Console.WriteLine($"\n🏆 {rycerz.Imie} WYGRYWA!");
        else
            Console.WriteLine($"\n🏆 {czarnoksieznik.Imie} WYGRYWA!");
    }
}
