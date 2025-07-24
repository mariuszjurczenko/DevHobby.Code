using DevHobby.Code.RPG;

public class Program
{
    static void Main()
    {
        // 2 sposób - klasy. Tworzymy pierwszego bohatera
        Bohater aragorn = new Bohater("Aragorn", 100, 25);
        Bohater legolas = new Bohater("Legolas", 80, 30);
        Bohater gimli = new Bohater("Gimli", 120, 35);

        // Możemy nawet stworzyć bohatera "w locie"
        Bohater[] druzyna = { 
            new Bohater("Frodo", 50, 10),
            new Bohater("Sam", 60, 15),
            new Bohater("Gandalf", 150, 40),
            aragorn,
            gimli, 
            legolas 
        };

        foreach (var bohater in druzyna)
        {
            Console.WriteLine($"{bohater.Imie} - HP: {bohater.PunktyZycia}, Siła: {bohater.Sila}");
        }

        // Problemy z publicznymi polami
        aragorn.PunktyZycia = 100;
        legolas.Sila = 9999;
        //gimli.Imie = "";

        Console.WriteLine($"{aragorn.Imie} ma {aragorn.PunktyZycia} HP");
        Console.WriteLine($"{legolas.Imie} ma {legolas.Sila} Sila");
        Console.WriteLine($"{gimli.Imie} ma {gimli.Sila} Sila");
    }
}
