namespace DevHobby.Code.RPG;

public class BohaterStary
{
    // Pola klasy - cechy każdego bohatera
    // Pola są teraz PRYWATNE - nikt z zewnątrz nie ma dostępu
    private string imie;
    private int puktyZycia;
    private int sila;

    // Właściwości - wyglądają jak pola, działają jak metody!
    public string Imie
    {
        get { return imie; }
        private set { imie = value; }
    }

    public int PunktyZycia
    {
        get { return puktyZycia; }
        set
        {
            if (value < 0)
            {
                puktyZycia = 0;
                Console.WriteLine($"{Imie}: HP ustawione na 0 (próbowano: {value})");
            }
            else
            {
                puktyZycia = value;
            }
        }
    }

    public int Sila
    {
        get { return sila; }
        set
        {
            if (value < 1)
            {
                sila = 1;
            }
            else if (value > 100)
            {
                sila = 100;
            }
            else
            {
                sila = value;
            }
        }
    }

    // Konstruktor - specjalna metoda wywoływana przy tworzeniu obiektu
    public BohaterStary(string imie, int puktyZycia, int sila)
    {
        // 'this' odnosi się do aktualnego obiektu
        Imie = imie;
        PunktyZycia = puktyZycia;
        Sila = sila;
    }
}
