using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;

namespace DevHobby.Code.RPG.Core.Services;

public class BattleService : IBattleService
{
    private readonly Random random = new Random();

    public event Action<string>? KomunikatWygenerowany;

    public Postac Sylumuj(IList<Postac> uczestnicy)
    {
        // Symulacja walki
        while (uczestnicy.Count(p => p.PunktyZycia > 0) > 1)
        {
            // Losowanie atakującego spośród żywych postaci
            var zywePostacie = uczestnicy.Where(p => p.PunktyZycia > 0).ToList();
            if (zywePostacie.Count <= 1) break;

            var atakujacy = zywePostacie[random.Next(zywePostacie.Count)];

            // Losowanie celu (różnego od atakującego)
            Postac cel;
            do
            {
                cel = zywePostacie[random.Next(zywePostacie.Count)];
            } while (cel == atakujacy);

            // Wykonanie ataku
            atakujacy.Atakuj(cel);

            // Krótka pauza, aby śledzić przebieg walki
            Thread.Sleep(1000);

            // Kontratak
            if (cel.PunktyZycia > 0)
            {
                cel.Atakuj(atakujacy);
            }

            // Czasem boharter się leczy
            if (atakujacy is Bohater bohater && atakujacy.PunktyZycia < 10 && atakujacy.PunktyZycia > 0)
            {
                GenerujKomunikat($"\n{atakujacy.Imie} używa mikstury!");
                bohater.Lecz(30);
            }

            Thread.Sleep(1000); // Pauza dla dramatyzmu          
        }

        return uczestnicy.First(p => p.PunktyZycia > 0);
    }

    protected void GenerujKomunikat(string tresc)
    {
        KomunikatWygenerowany?.Invoke(tresc);
    }
}
