namespace DevHobby.Code.RPG;

public class Smok : Potwor
{
    public Smok() : base("Smok", 100, 30)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        GenerujKomunikat($"\n 🔥 {Imie} zieje ogniem na {cel.Imie}!");
        int obrazenia = Sila * 2;
        GenerujKomunikat($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
