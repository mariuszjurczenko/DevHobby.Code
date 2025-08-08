namespace DevHobby.Code.RPG;

public class Mag : Bohater
{
    public Mag(string imie) : base(imie, 80, 40)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n ✨ Mag {Imie} rzuca potężne zaklęcie na {cel.Imie}!");
        int obrazenia = (int)(Sila * 1.5); // Mag zadaje stałe, duże obrażenia
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
