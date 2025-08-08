namespace DevHobby.Code.RPG;

public abstract class Potwor : Postac
{
    public Potwor(string imie, int punktyZycia, int sila) : base(imie, punktyZycia, sila)
    { }

    public override void PokazStatus()
    {
        string pasekHP = new string('█', PunktyZycia / 10) +
                        new string('░', (100 - PunktyZycia) / 10);

        Console.WriteLine($"\n=== {Imie} ===");
        Console.WriteLine($"HP: [{pasekHP}] {PunktyZycia}/100");
        Console.WriteLine($"Siła: {Sila}");
    }
}
