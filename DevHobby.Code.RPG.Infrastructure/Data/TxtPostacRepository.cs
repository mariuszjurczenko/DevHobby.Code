using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;

namespace DevHobby.Code.RPG.Infrastructure.Data;

public class TxtPostacRepository : IPostacRepository
{
    private readonly IPostacFactory _postacFactory;

    public TxtPostacRepository(IPostacFactory postacFactory)
    {
        _postacFactory = postacFactory;
    }

    public List<Postac> PobierzPostacie(string sciezka)
    {
        var lista = new List<Postac>();

        foreach (var linia in File.ReadAllLines(sciezka))
        {
            if (string.IsNullOrWhiteSpace(linia) || linia.StartsWith("#"))
                continue;

            var czesci = linia.Split(',');
            if (czesci.Length != 2) continue;

            var kategoria = czesci[0].Split(':')[0].Trim().ToLower();
            var typ = czesci[0].Split(':')[1].Trim();
            var imie = czesci[1].Trim();

            if (kategoria == "bohater")
                lista.Add(_postacFactory.StworzBohatera(typ, imie));
            else if (kategoria == "potwor")
                lista.Add(_postacFactory.StworzPotwora(typ));
        }

        return lista;
    }
}
