namespace DevHobby.Code.RPG;

public abstract class Bohater : Postac
{
    // Właściwości auto-implemented
    public int Poziom { get; protected set; } = 1;

    // Konstruktor
    public Bohater(string imie, int punktyZycia, int sila) : base(imie, punktyZycia, sila)
    {}

    // Metoda leczenia
    public void Lecz(int punkty)
    {
        if (PunktyZycia == 0)
        {
            GenerujKomunikat($"{Imie} nie może się leczyć - jest pokonany!");
            return;
        }

        int stareHP = PunktyZycia;
        PunktyZycia = Math.Min(PunktyZycia + punkty, 100);

        GenerujKomunikat($"✨ {Imie} leczy się o {PunktyZycia - stareHP} HP!");
        GenerujKomunikat($"   Aktualne HP: {PunktyZycia}/100");
    }
    
    // Metoda wyświetlania statusu
    public override void PokazStatus()
    {
        string pasekHP = new string('█', PunktyZycia / 10) +
                        new string('░', (100 - PunktyZycia) / 10);

        GenerujKomunikat($"\n=== {Imie} ===");
        GenerujKomunikat($"HP: [{pasekHP}] {PunktyZycia}/100");
        GenerujKomunikat($"Siła: {Sila} | Poziom: {Poziom}");
    }
}
