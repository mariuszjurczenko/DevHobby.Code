using DevHobby.Code.RPG.Core.Entities;

namespace DevHobby.Code.RPG.Core.Interfaces;

public interface IBattleService
{
    Postac Sylumuj(IList<Postac> uczestnicy);
}
