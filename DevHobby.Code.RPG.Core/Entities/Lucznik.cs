namespace DevHobby.Code.RPG.Core.Entities;

public class Lucznik : Bohater
{
    public Lucznik(string imie) : base(imie, 90, 20)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        GenerujKomunikat($"\n 🏹 Lucznik {Imie} strzela celnie w {cel.Imie}!");
        int obrazenia = (int)(Sila * 1.2) + new Random().Next(1, 5);
        GenerujKomunikat($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
