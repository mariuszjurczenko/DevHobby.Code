using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;
using System.Text.Json;

namespace DevHobby.Code.RPG.Infrastructure.Data;

public class JsonPostacRepository : IPostacRepository
{
    private readonly IPostacFactory _postacFactory;

    public JsonPostacRepository(IPostacFactory postacFactory)
    {
        _postacFactory = postacFactory;
    }

    public List<Postac> PobierzPostacie(string sciezka)
    {
        var json = File.ReadAllText(sciezka);
        var configList = JsonSerializer.Deserialize<List<PostacDto>>(json);

        var lista = new List<Postac>();

        foreach (var cfg in configList)
        {
            if (cfg.Kategoria.ToLower() == "bohater")
                lista.Add(_postacFactory.StworzBohatera(cfg.Typ, cfg.Imie));
            else if (cfg.Kategoria.ToLower() == "potwor")
                lista.Add(_postacFactory.StworzPotwora(cfg.Typ));
        }

        return lista;
    }
}
