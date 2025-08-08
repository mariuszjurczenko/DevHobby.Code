namespace DevHobby.Code.RPG;

public class Smok : Potwor
{
    public Smok() : base("Smok", 100, 30)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        Console.WriteLine($"\n 🔥 {Imie} zieje ogniem na {cel.Imie}!");
        int obrazenia = Sila * 2; // Smok jest bardzo potężny i zadaje podwójne obrażenia
        Console.WriteLine($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
