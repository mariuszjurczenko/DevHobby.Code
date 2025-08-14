using System.Text.Json;

namespace DevHobby.Code.RPG
{
    public class PostacFactory : IPostacFactory
    {
        public Postac StworzBohatera(string typ, string imie)
        {
            return typ.ToLower() switch
            {
                "wojownik" => new Wojownik(imie),
                "lucznik" => new Lucznik(imie),
                "mag" => new Mag(imie),
                _ => throw new ArgumentException($"Nieznany typ bohatera: {typ}")
            };
        }

        public Postac StworzPotwora(string typ)
        {
            return typ.ToLower() switch
            {
                "ork" => new Ork(),
                "goblin" => new Goblin(),
                "smok" => new Smok(),
                _ => throw new ArgumentException($"Nieznany typ potwora: {typ}")
            };
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
}
