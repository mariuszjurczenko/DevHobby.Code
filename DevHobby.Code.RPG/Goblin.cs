namespace DevHobby.Code.RPG;

public class Goblin : Potwor
{
    public Goblin() : base("Goblin", 60, 15)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n 🐍 {Imie} rzuca zatruty sztylet w {cel.Imie}!");
        int obrazenia = (int)(Sila * 0.9); // Goblin zadaje mniej obrażeń
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
