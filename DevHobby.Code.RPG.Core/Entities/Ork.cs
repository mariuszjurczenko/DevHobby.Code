namespace DevHobby.Code.RPG.Core.Entities;

public class Ork : Potwor
{
    public Ork() : base("Ork", 80, 20)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        GenerujKomunikat($"\n 👺 {Imie} uderza maczugą w {cel.Imie}!");
        int obrazenia = Sila + 3;
        GenerujKomunikat($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
