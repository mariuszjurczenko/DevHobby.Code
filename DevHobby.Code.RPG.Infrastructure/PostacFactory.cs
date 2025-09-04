using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;

namespace DevHobby.Code.RPG.Infrastructure;

public class PostacFactory : IPostacFactory
{
    public Postac StworzBohatera(string typ, string imie)
    {
        Postac postac = typ.ToLower() switch
        {
            "wojownik" => new Wojownik(imie),
            "lucznik" => new Lucznik(imie),
            "mag" => new Mag(imie),
            _ => throw new ArgumentException($"Nieznany typ bohatera: {typ}"),
        };
        return postac;
    }

    public Postac StworzPotwora(string typ)
    {
        Postac postac = typ.ToLower() switch
        {
            "ork" => new Ork(),
            "goblin" => new Goblin(),
            "smok" => new Smok(),
            _ => throw new ArgumentException($"Nieznany typ potwora: {typ}"),
        };
        return postac;
    }
}
