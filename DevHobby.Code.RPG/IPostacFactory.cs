namespace DevHobby.Code.RPG
{
    public interface IPostacFactory
    {
        Postac StworzBohatera(string typ, string imie);
        Postac StworzPotwora(string typ);
    }
}
