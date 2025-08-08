namespace DevHobby.Code.RPG;

public class Ork : Potwor
{
    public Ork() : base("Ork", 80, 20)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n 👺 {Imie} uderza maczugą w {cel.Imie}!");
        int obrazenia = Sila + 3; // Ork zadaje obrażenia większe o stałą wartość
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
