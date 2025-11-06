namespace PeopleApp;

using Packt.Shared;
using System.Reflection.Metadata;
using Env = System.Environment;

public partial class Program
{
    static void Main(string[] args)
    {
        ConfigureConsole();

        //WriteLine(Env.OSVersion);
        //WriteLine(Env.MachineName);
        //WriteLine(Env.CurrentDirectory);

        //Person bob = new();
        //bob.Name = "Bob Smith";
        //bob.Born = new DateTimeOffset(
        //    year: 1965, month: 12, day: 22,
        //    hour: 16, minute: 28, second: 0,
        //    offset: TimeSpan.FromHours(-5));
        //bob.FavoriteWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
        //bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
        //    | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
        //WriteLine(format: "{0} was born on {1:D}", bob.Name, bob.Born);
        //WriteLine("{0}'s favorite wonder is {1}. Its' integer is {2}", arg0: bob.Name, arg1: bob.FavoriteWonder, arg2: (int)bob.FavoriteWonder);
        //WriteLine("{0}'s bucket list is {1}", arg0: bob.Name, arg1: bob.BucketList);

        //Person alfred = new Person();
        //alfred.Name = "Alfred";
        //bob.Children.Add(alfred);
        //// Works with C# 3 and later.
        //bob.Children.Add(new Person { Name = "Bella" });
        //// Works with C# 9 and later.
        //bob.Children.Add(new() { Name = "Zoe" });
        //WriteLine($"{bob.Name} has {bob.Children.Count} children:");

        //for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
        //{
        //    WriteLine($"  {bob.Children[childIndex].Name}");
        //}

        //Person alice = new()
        //{
        //    Name = "Alice Jones",
        //    Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
        //};

        //WriteLine(format: "{0} was born on {1:d}", alice.Name, alice.Born);

        //BankAccount.InterestRate = 0.012M;
        //BankAccount jonesAccount = new();
        //jonesAccount.AccountName = "Jones Savings Account";
        //jonesAccount.Balance = 2400;
        //WriteLine(format: "{0} earned {1:C} interest.",
        //    arg0: jonesAccount.AccountName,
        //    arg1: jonesAccount.Balance * BankAccount.InterestRate);

        //BankAccount gerrierAccount = new();
        //gerrierAccount.AccountName = "Gerrier Savings Account";
        //gerrierAccount.Balance = 98;
        //WriteLine(format: "{0} earned {1:C} interest.",
        //    arg0: gerrierAccount.AccountName,
        //    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

        //Book book = new()
        //{
        //    Isbn = "978-1803237800",
        //    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
        //};
        Book book = new(isbn: "978-1803237800",
            title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals");

        WriteLine("{0}: {1} written by {2} has {3:N0} pages.", book.Isbn, book.Title, book.Author, book.PageCount);

        Person blankPerson = new();
        WriteLine(format:
          "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
          arg0: blankPerson.Name,
          arg1: blankPerson.HomePlanet,
          arg2: blankPerson.Instantiated);

        Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
        WriteLine(format:
          "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
          arg0: gunny.Name,
          arg1: gunny.HomePlanet,
          arg2: gunny.Instantiated);

        gunny.WriteToConsole();
        WriteLine(gunny.SayHello());
        WriteLine(gunny.SayHello("Jenny"));
        WriteLine(gunny.OptionalParameters());
        int some = 3;
        gunny.PassingParameters(1, 2, ref some, out int z);
        WriteLine("our some is {0} and our out z is {1}", some, z);
        gunny.ParamsParameters("Hello", 1, 2, 3, 4, 5);
        var fruit = gunny.GetFruit();
        WriteLine("I have a {0} and {1} seeds.", fruit.Name, fruit.Number);

        var (name1, dob1) = gunny; // Implicitly calls the Deconstruct method.
        WriteLine($"Deconstructed person: {name1}, {dob1}");
        var (name2, dob2, fav2) = gunny;
        WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

        int number = 5;
        try
        {
            WriteLine($"{number}! is {Person.Factorial(number)}");
        }
        catch (Exception ex)
        {
            WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
        }

        Person sam = new()
        {
            Name = "Sam",
            Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
        };
        WriteLine(sam.Origin);
        WriteLine(sam.Greeting);
        WriteLine(sam.Age);

        sam.FavoriteIceCream = "Chocolate Fudge";
        WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
        string color = "Red";
        try
        {
            sam.FavoritePrimaryColor = color;
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
        }
        catch (Exception ex)
        {
            WriteLine("Tried to set {0} to '{1}': {2}",
              nameof(sam.FavoritePrimaryColor), color, ex.Message);
        }

        Passenger[] passengers = {
            new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
            new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
            new BusinessClassPassenger { Name = "Janice" },
            new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
            new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
        };
        foreach (Passenger passenger in passengers)
        {
            decimal flightCost = passenger switch
            {
                /* C# 8 syntax
                FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
                FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
                FirstClassPassenger _                          => 2_000M, */
                // C# 9 or later syntax
                FirstClassPassenger p => p.AirMiles switch
                {
                    > 35_000 => 1_500M,
                    > 15_000 => 1_750M,
                    _ => 2_000M
                },
                BusinessClassPassenger => 1_000M,
                CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                CoachClassPassenger => 650M,
                _ => 800M
            };
            WriteLine($"Flight costs {flightCost:C} for {passenger}");
        }

        ImmutableVehicle car = new()
        {
            Brand = "Mazda MX-5 RF",
            Color = "Soul Red Crystal Metallic",
            Wheels = 4
        };
        ImmutableVehicle repaintedCar = car with
            { Color = "Polymetal Grey Metallic" };
        WriteLine($"Original car color was {car.Color}.");
        WriteLine($"New car color is {repaintedCar.Color}.");

        AnimalClass ac1 = new() { Name = "Rex" };
        AnimalClass ac2 = new() { Name = "Rex" };
        WriteLine($"ac1 == ac2: {ac1 == ac2}");
        AnimalRecord ar1 = new() { Name = "Rex" };
        AnimalRecord ar2 = new() { Name = "Rex" };
        WriteLine($"ar1 == ar2: {ar1 == ar2}");

        Headset vp = new("Apple", "Vision Pro");
        WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}.");
    }
}