
#region Create drinks
using Microsoft.VisualBasic;

List<Drink> drinks = new List<Drink>();
drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
#endregion

Console.WriteLine("Opgave 1");
//1.    The names of all drinks.
var allDrinkNames = from d in drinks 
                    select d.Name;

foreach(var name in allDrinkNames) {
    Console.WriteLine(name);
}

Console.WriteLine("\nOpgave 2");
//2.	The names of all drinks without alcohol.
var allDrinksWithoutAlcohol = from d in drinks
                              where d.AlcoholicPart == "None"
                              select d.Name;
foreach (var name in allDrinksWithoutAlcohol) {
    Console.WriteLine(name);
}

Console.WriteLine("\nOpgave 3");
//3.	The name, alcohol part and alcohol amount for all drinks with alcohol.
var alcoholicDrinksAndParts = from d in drinks
                              where d.AlcoholicPart != "None"
                              select new { d.Name, d.AlcoholicPart, d.AlcoholicPartAmount };
foreach (var name in alcoholicDrinksAndParts) {
    Console.WriteLine($"Name: {name.Name}, AlcohlicPart: {name.AlcoholicPart}, AlcoholicPartAmount: {name.AlcoholicPartAmount}");
}

Console.WriteLine("\nOpgave 4");
//4.	The names of all drinks in alphabetical order.
var sortedDrinks = drinks.OrderBy(n => n.Name);
foreach (var name in sortedDrinks) {
    Console.WriteLine(name.Name);
}

Console.WriteLine("\nOpgave 5");
//5.	The total amount of alcohol in the drinks.
Console.WriteLine((from d in drinks select d.AlcoholicPartAmount).Sum());


Console.WriteLine("\nOpgave 6");
//6.	The average amount of alcohol in drinks with alcohol.
Console.WriteLine((from d in drinks select d.AlcoholicPartAmount).Average());


Console.WriteLine("\nOpgave 7");
//7.	The name and alcohol amount of each drink, grouped by name of alcohol part (NB: We have not discussed grouping in class!Seek information about the group LINQ operator online in order to solve this case )
var groupByNameAndAlcoholAmount = from d in drinks
                                  group d by d.AlcoholicPart into newGroup
                                  orderby newGroup.Key
                                  select newGroup;
foreach (var group in groupByNameAndAlcoholAmount) {
    Console.WriteLine($"Key: {group.Key}");
    foreach (var d in group) {
        Console.WriteLine($"\tName: {d.Name}, AlcoholAmount: {d.AlcoholicPartAmount}\n");
    }
}