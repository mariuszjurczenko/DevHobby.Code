using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;
using DevHobby.Code.RPG.Infrastructure.Data;
using System.Text.Json;

namespace DevHobby.Code.RPG.Infrastructure;

public class PostacFactory : IPostacFactory
{
    public Postac StworzBohatera(string typ, string imie)
    {
        Postac postac;

        switch (typ.ToLower())
        {
            case "wojownik":
                postac = new Wojownik(imie);
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            case "lucznik":
                postac = new Lucznik(imie);
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            case "mag":
                postac = new Mag(imie);
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            default:
                throw new ArgumentException($"Nieznany typ bohatera: {typ}");
        }

        return postac;
    }

    public Postac StworzPotwora(string typ)
    {
        Postac postac;

        switch (typ.ToLower())
        {
            case "ork":
                postac = new Ork();
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            case "goblin":
                postac = new Goblin();
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            case "smok":
                postac = new Smok();
                postac.KomunikatWygenerowany += Console.WriteLine;
                break;
            default:
                throw new ArgumentException($"Nieznany typ potwora: {typ}");
        }

        return postac;
    }

    public List<Postac> WczytajPostacieZPliku(string sciezka)
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
                lista.Add(StworzBohatera(typ, imie));
            else if (kategoria == "potwor")
                lista.Add(StworzPotwora(typ));
        }

        return lista;
    }

    public List<Postac> WczytajPostacieZJson(string sciezka)
    {
        var json = File.ReadAllText(sciezka);
        var configList = JsonSerializer.Deserialize<List<PostacConfig>>(json);

        var lista = new List<Postac>();

        foreach (var cfg in configList)
        {
            if (cfg.Kategoria.ToLower() == "bohater")
                lista.Add(StworzBohatera(cfg.Typ, cfg.Imie));
            else if (cfg.Kategoria.ToLower() == "potwor")
                lista.Add(StworzPotwora(cfg.Typ));
        }

        return lista;
    }
}
