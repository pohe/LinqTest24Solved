// See https://aka.ms/new-console-template for more information
using LinqTest24;

Console.WriteLine("Hello, LINQ Test 24!");

List<string> names = new List<string>() { "Jacob", "Katrine", "Molle", "Gustav", "Jonas", "Marius", "Kim", "Magnus", "Stephane" };

//Opgave 1
// Find antallet af navne i listen names?
//Udskriv resultatet
Console.WriteLine("Opgave 1");
int numbersOfNames = names.Count();

Console.WriteLine($"Number of names {numbersOfNames}");

var numOfNames2 = (from name in names select name).Count();

Console.WriteLine($"Number of names {numOfNames2}");

//Opgave 2
// Find den gennemsnitlige længde af navnene i names?
//Udskriv resultatet
Console.WriteLine("Opgave 2");
var averageLength = (from name in names select name.Length).Average();
Console.WriteLine($"Average length of names {averageLength}");


//Opgave 3
//Udskriv navnene i names sorteret
Console.WriteLine("Opgave 3");
var result = from name in names
             orderby name
             select name;

foreach (var name in result)
{
    Console.WriteLine(name);
}


List<int> numbers = new List<int> { 5, 12, 8, 3, 15, 20, 10, 5, 7 };

//Opgave 4
//Find summen af alle tal over 10
//Udskriv resultatet

Console.WriteLine("Opgave 4");
var resultSum = numbers.Where(n => n > 10).Sum();

Console.WriteLine($"resultSum {resultSum}");





#region Create List of movies
List<Movie> movies = new List<Movie>()
            {
                new Movie{Title ="Se7en", Year = 1995, DurationInMins = 127, StudioName="New Line Cinema"},
                new Movie{Title = "Alien", Year = 1979, DurationInMins = 117, StudioName="20th Century Fox"},
                new Movie{Title = "Forrest Gump", Year = 1994, DurationInMins = 142, StudioName="Paramount Pictures"},
                new Movie{Title = "True Grit", Year = 2010, DurationInMins = 110, StudioName="Paramount Pictures"},
                new Movie{Title = "Dark City", Year = 1998, DurationInMins = 111, StudioName="New Line Cinema"},

            };
#region Create actors
movies[0].Actors = new List<Actor>() { new Actor() { Name = "Dustin Hoffmann" }, new Actor() { Name = "Denzel Washington" } };
movies[1].Actors = new List<Actor>() { new Actor() { Name = "Meryl Streep" }, new Actor() { Name = "Jack Nicholson" } };
movies[2].Actors = new List<Actor>() { new Actor() { Name = "Ralph Fiennes" }, new Actor() { Name = "Sigourney Weaver" } };
movies[3].Actors = new List<Actor>() { new Actor() { Name = "Robert De Niro" }, new Actor() { Name = "Al Pacino" }, new Actor() { Name = "Sigourney Weaver" } };
movies[4].Actors = new List<Actor>() { new Actor() { Name = "Dustin Hoffmann" }, new Actor() { Name = " Jack Nicholson" } };
#endregion

#region create list of studios
List<Studio> studios = new List<Studio>()
            {
                new Studio{StudioName = "New Line Cinema", HQCity = "Boston", NoOfEmployees = 4000},
                new Studio{StudioName = "20th Century Fox", HQCity = "New York", NoOfEmployees = 2500},
                new Studio{StudioName = "Paramount Pictures", HQCity = "New York", NoOfEmployees = 8000}

            };
#endregion


//Opgave 5
//Find film der varer mere end 2 timer
//Udskriv resultatet
Console.WriteLine("Opgave 5");
Console.WriteLine("find film der varer mere end 2 timer");
var moviesAbove2Hours = from m in movies
                        where m.DurationInMins > 120
                        select m.Title;

foreach (var mwd in moviesAbove2Hours)
{
    Console.WriteLine(mwd);
}


//Opgave 6
//Find alle studioes (studionames) fra New York med mere end 3000 ansatte
//Udskriv resultatet
Console.WriteLine("Opgave 6");

var studioeNewYorkMoreThan3000 = from s in studios
                                 where s.HQCity == "New York" && s.NoOfEmployees >3000
                                 select s;
foreach (var snm in studioeNewYorkMoreThan3000)
{
    Console.WriteLine(snm.StudioName);
}

//Opgave 7
//Find alle movies, som har mere end to skuespillere
//Udskriv resultatet
Console.WriteLine("Opgave 7");

var movieWithMorethan2Actors = from m in movies
                               where m.Actors.Count > 2
                               select m;
foreach (var mw2a in movieWithMorethan2Actors)
{
    Console.WriteLine(mw2a.Title);
}      

//Opgave 8
//Find alle movies som Dustin Hoffman spiller med i?
//Udskriv resultatet
Console.WriteLine("Opgave 8");

Console.WriteLine("Find alle movies som Dustin Hoffman spiller med i ved at bruge Linq og lambda?");
//var moviesWithDustinHoffman2 = movies.Where(m => m.Actors.FindAll(a => a.Name == "Dustin Hoffmann").Count != 0).Select(m => m.Title);
var moviesWithDustinHoffman2 = from m in movies
                               where (from a in m.Actors
                                      where a.Name =="Dustin Hoffmann"
                                      select a).Count() != 0
                                select m.Title;

//var fluentOpg8 = movies.Where(m => m.Actors.Where(a => a.Name == "Dustin Hoffmann").Count()!=0);
foreach (var mwd in moviesWithDustinHoffman2)
{
    Console.WriteLine(mwd);
}
Console.WriteLine("Slut");




#endregion


//Ekstra opgaver til de hurtigste

//Opgave 9
//Find de 2 laveste ulige tal i listen numbers og udskriv dem i stigende orden
Console.WriteLine("Opgave 9");

var lowestOddNumbers = numbers.Where(n => n % 2 != 0).OrderBy(n => n).Take(2);

foreach (var number in lowestOddNumbers)
{
    Console.WriteLine(number);
}


//Opgave 10
//Find de 2 højeste ulige tal i listen numbers og som der ikke forekommer dubletter af og udskriv dem i falden orden
Console.WriteLine("Opgave 10");

var lowestDistinctOddNumbers = numbers.Where(n => n % 2 != 0).Distinct().OrderByDescending(n => n).Take(2);

foreach (var number in lowestDistinctOddNumbers)
{
    Console.WriteLine(number);
}


//Opgave 11
// Find alle movies 
//var moviesWithStudioInNYAndMoreThan3000Employees = from movie in movies
//                                                   join studio in studios on movie.StudioName equals studio.StudioName
//                                                   where studio.HQCity == "New York" && studio.NoOfEmployees > 3000
//                                                   select movie;

//var moviesWithDustinHoffman = moviesWithStudioInNYAndMoreThan3000Employees.Where(movie => movie.Actors.Any(actor => actor.Name == "Dustin Hoffman"));

//foreach (var movie in moviesWithDustinHoffman)
//{
//    Console.WriteLine(movie.Title);
//}
