namespace DevHobby.Code.RPG.Core.Entities;

public class Mag : Bohater
{
    public Mag(string imie) : base(imie, 80, 40)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        GenerujKomunikat($"\n ✨ Mag {Imie} rzuca potężne zaklęcie na {cel.Imie}!");
        int obrazenia = (int)(Sila * 1.5);
        GenerujKomunikat($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
