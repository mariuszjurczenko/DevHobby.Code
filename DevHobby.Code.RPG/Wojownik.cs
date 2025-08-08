namespace DevHobby.Code.RPG;

public class Wojownik : Bohater
{
    public Wojownik(string imie) : base(imie, 100, 30)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n ⚔️ Wojownik {Imie} uderza z furią {cel.Imie}!");
        int obrazenia = (int)(Sila * (0.8 + new Random().NextDouble() * 0.4));
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
