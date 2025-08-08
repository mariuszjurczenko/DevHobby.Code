namespace DevHobby.Code.RPG;

public abstract class Postac
{
     // Właściwości auto-implemented (skrócona składnia)
    public string Imie { get; protected set; }
    public int PunktyZycia { get; protected set; }
    public int MaxPunktyZycia { get; protected set; } // Maksymalne HP dla każdej postaci
    public int Sila { get; protected set; }
    
    // Konstruktor
    public Postac(string imie, int punktyZycia, int sila)
    {
        Imie = imie;
        MaxPunktyZycia = punktyZycia > 0 ? punktyZycia : 1;
        PunktyZycia = MaxPunktyZycia;
        Sila = Math.Clamp(sila, 1, 100);  // Ogranicza wartość do zakresu
    }

    // Metoda ataku
    public virtual void Atakuj(Postac cel)
    {
        if (PunktyZycia <= 0)
        {
            Console.WriteLine($"{Imie} nie może atakować - jest pokonany!");
            return;
        }

        if (cel.PunktyZycia <= 0)
        {
            Console.WriteLine($"{cel.Imie} jest już pokonany!");
            return;
        }
    }

    // Metoda otrzymywania obrażeń (prywatna!)
    protected internal void OtrzymajObrazenia(int obrazenia)
    {
        PunktyZycia -= obrazenia;
        if (PunktyZycia < 0) PunktyZycia = 0;

        Console.WriteLine($"   {Imie} ma teraz {PunktyZycia}/{100} HP");

        if (PunktyZycia == 0)       
            Console.WriteLine($"💀 {Imie} został pokonany!");
    }

    // Metoda wyświetlania statusu
    public abstract void PokazStatus();
}
