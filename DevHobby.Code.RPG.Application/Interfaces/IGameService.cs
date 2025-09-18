using DevHobby.Code.RPG.Core.Entities;

namespace DevHobby.Code.RPG.Application.Interfaces;

public interface IGameService
{
    IReadOnlyList<Postac> Postacie { get; }

    void PobierzPostacie(string sciezkaPliku);
    Postac Start();
    void WyswietlStatusy();
}