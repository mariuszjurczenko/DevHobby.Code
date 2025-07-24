namespace DevHobby.Code.Lego;

internal class Dog
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }

    public void Bark()
    {
        Console.WriteLine("Hau hau");
    }

    public void IntroduceYourself()
    {
        Console.WriteLine($"Czesc, jestem {Name}, mam {Age} lat i jestem rasy {Breed}");
    }
}