namespace DevHobby.Code.RPG;

public class Bohater
{
    // Właściwości auto-implemented (skrócona składnia)
    public string Imie { get; private set; }
    public int PunktyZycia { get; private set; }
    public int Sila { get; private set; }
    public int Poziom { get; private set; }

    // Konstruktor
    public Bohater(string imie, int punktyZycia, int sila)
    {
        Imie = imie;
        PunktyZycia = punktyZycia > 0 ? punktyZycia : 1;
        Sila = Math.Clamp(sila, 1, 100);  // Ogranicza wartość do zakresu
        Poziom = 1;
    }

    // Metoda ataku
    public void Atakuj(Bohater cel)
    {
        if (PunktyZycia <= 0)
        {
            Console.WriteLine($"{Imie} nie może atakować - jest pokonany!");
            return;
        }

        Console.WriteLine($"\n⚔️ {Imie} atakuje {cel.Imie}!");

        // Losowy modyfikator ataku (80% - 120% siły)
        Random rand = new Random();
        int obrazenia = (int)(Sila * (0.8 + rand.NextDouble() * 0.4));

        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }

    // Metoda otrzymywania obrażeń (prywatna!)
    private void OtrzymajObrazenia(int obrazenia)
    {
        PunktyZycia -= obrazenia;
        if (PunktyZycia < 0) PunktyZycia = 0;

        Console.WriteLine($"   {Imie} ma teraz {PunktyZycia}/{100} HP");

        if (PunktyZycia == 0)       
            Console.WriteLine($"💀 {Imie} został pokonany!");
    }

    // Metoda leczenia
    public void Lecz(int punkty)
    {
        if (PunktyZycia == 0)
        {
            Console.WriteLine($"{Imie} nie może się leczyć - jest pokonany!");
            return;
        }

        int stareHP = PunktyZycia;
        PunktyZycia = Math.Min(PunktyZycia + punkty, 100); // Max 100 HP

        Console.WriteLine($"✨ {Imie} leczy się o {PunktyZycia - stareHP} HP!");
        Console.WriteLine($"   Aktualne HP: {PunktyZycia}/100");
    }
    
    // Metoda wyświetlania statusu
    public void PokazStatus()
    {
        string pasekHP = new string('█', PunktyZycia / 10) + 
                        new string('░', (100 - PunktyZycia) / 10);
        
        Console.WriteLine($"\n=== {Imie} ===");
        Console.WriteLine($"HP: [{pasekHP}] {PunktyZycia}/100");
        Console.WriteLine($"Siła: {Sila} | Poziom: {Poziom}");
    }
}
