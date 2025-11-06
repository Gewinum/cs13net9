namespace Packt.Shared; // this is file-scoped namespace declaration

public partial class Person
{
    #region Constants
    public const string Species = "Homo Sapiens";
    #endregion

    #region Fields: Data or state for this person 
    public string? Name;

    public DateTimeOffset Born;

    // This has been moved to PersonAutoGen.cs as a property.
    // public WondersOfTheAncientWorld FavoriteAncientWonder;

    public WondersOfTheAncientWorld BucketList;

    public List<Person> Children = new();

    public readonly string HomePlanet = "Earth";

    public readonly DateTime Instantiated;
    #endregion

    #region Constructors
    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    #endregion

    #region Deconstructors
    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name,
        out DateTimeOffset dob,
        out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
    }
    #endregion

    #region Methods: Actions the type can perform
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public string SayHello()
    {
        return $"{Name} says hello!";
    }

    public string SayHello(string to)
    {
        return $"{Name} says hello to {to}!";
    }

    public string OptionalParameters(string command = "Run!",
        double number = 0.0, bool active = true)
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active);
    }

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        z = 100;
        w++;
        y++;
        z++;

        WriteLine($"In the method: w = {w}, x = {x}, y = {y}, z = {z}");
    }

    public void ParamsParameters(
        string text, params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        WriteLine($"{text}: {total}");
    }

    public (string Name, int Number) GetFruit()
    {
        return ("Apples", 5);
    }

    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);
        int localFactorial(int localNumber) // Local function.
        {
            if (localNumber == 0)
            {
                return 1;
            }

            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion
}