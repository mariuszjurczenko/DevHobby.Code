using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;
using DevHobby.Code.RPG.Infrastructure.Interfaces;
using System.Text.Json;

namespace DevHobby.Code.RPG.Infrastructure.Data;

public class JsonPostacRepository : IPostacRepository
{
    private readonly IPostacFactory _postacFactory;
    private readonly IFileReader _fileReader;

    public JsonPostacRepository(IPostacFactory postacFactory, IFileReader fileReader)
    {
        _postacFactory = postacFactory;
        _fileReader = fileReader;
    }

    public List<Postac> PobierzPostacie(string sciezka)
    {
        var json = _fileReader.ReadAllText(sciezka);
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
