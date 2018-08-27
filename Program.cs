using System;
using System.Collections.Generic;

namespace expressionMembers
{

  public class Bug
{
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
    public string Name { get; } = "";
    public string Species { get; } = "";
    public ICollection<string> Predators { get; } = new List<string>();
    public ICollection<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
    public string FormalName => $"{this.Name} {this.Species}";

    // Class constructor
    public Bug(string name, string species, List<string> predators, List<string> prey)
    {
        this.Name = name;
        this.Species = species;
        this.Predators = predators;
        this.Prey = prey;
    }

    // Convert this method to an expression member
    public string PreyList()
    {
        var commaDelimitedPrey = string.Join(",", this.Prey);
        return commaDelimitedPrey;
    }

    public string PreyListExpress => string.Join(",", this.Prey);

    // Convert this method to an expression member
    public string PredatorList()
    {
        var commaDelimitedPredators = string.Join(",", this.Predators);
        return commaDelimitedPredators;
    }

    public string PredatorListExpres => string.Join(",", this.Predators);

    // Convert this to expression method (hint: use a C# ternary)
    public string Eat(string food)
    {
        if (this.Prey.Contains(food))
        {
            return $"{this.Name} ate the {food}.";
        } else {
            return $"{this.Name} is still hungry.";
        }
    }

    public string EatExpress(string foods) => this.Prey.Contains(foods) ? $"{this.Name} ate the {foods}" : $"{this.Name} is still hungry.";
}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> predators = new List<string>(){
              "AngryBird",
              "SMallBird",
              "BigBird"
            };

            List<string> prey = new List<string>(){
              "SmallerBugs",
              "Even Smaller Bugs",
              "The smallest bugs"
            };

            Bug mrBug = new Bug("Bugman", "Awesome Bug", predators, prey){};
            Console.WriteLine($"{mrBug.PreyListExpress}");
            Console.WriteLine($"{mrBug.PredatorListExpres}");
            Console.WriteLine($"{mrBug.Eat("The smallest bugs")}");
        }
    }
}
