using DevHobby.Code.RPG.Core.Entities;

namespace DevHobby.Code.RPG.Core.Interfaces;

public interface IPostacFactory
{
    Postac StworzBohatera(string typ, string imie);
    Postac StworzPotwora(string typ);
}
