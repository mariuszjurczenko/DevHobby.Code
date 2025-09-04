using DevHobby.Code.RPG.Core.Entities;

namespace DevHobby.Code.RPG.Core.Interfaces;

public interface IPostacRepository
{
    List<Postac> PobierzPostacie(string sciezka);
}
