namespace DevHobby.Code.RPG;

public class Lucznik : Bohater
{
    public Lucznik(string imie) : base(imie, 90, 20)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n 🏹 Lucznik {Imie} strzela celnie w {cel.Imie}!");
        int obrazenia = (int)(Sila * 1.2) + new Random().Next(1, 5); // Łucznik ma bonus do siły, ale mniejszy losowy modyfikator
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
