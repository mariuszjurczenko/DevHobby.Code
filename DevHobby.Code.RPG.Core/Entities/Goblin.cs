namespace DevHobby.Code.RPG.Core.Entities;

public class Goblin : Potwor
{
    public Goblin() : base("Goblin", 60, 15)
    {
    }

    public override void Atakuj(Postac cel)
    {
        base.Atakuj(cel);

        GenerujKomunikat($"\n 🐍 {Imie} rzuca zatruty sztylet w {cel.Imie}!");
        int obrazenia = (int)(Sila * 0.9);
        GenerujKomunikat($"   Zadaje {obrazenia} obrażeń!");
        cel.OtrzymajObrazenia(obrazenia);
    }
}
