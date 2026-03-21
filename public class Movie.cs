public class Movie
{
    public string Title {get; }
    public string Director {get; }
    public int Year {get; }
    public double Rating {get; }
    public string? Description {get; }
    public Movie (string title, string director, int year, double rating, string? description)
    {
        Title = title; Director = director; Year = year; Rating = rating; Description = description;
        _totalMovies++;
    }
    public override string ToString()
    => $"{Title} ({Year}) - {Director}";

    public override bool Equals(object? obj)
    {
        if (obj is not Movie other) return false;
        return Title == other.Title
        && Director == other.Director
        && Year == other.Year; 
    }
    public override int GetHashCode()
    => HashCode.Combine(Title, Director, Year);
    private static int _totalMovies = 0;
    public static int TotalMovies => _totalMovies;

    string desc = Movie.Description ?? "No description";
}

public static class MovieUtils
{
    public static List<Movie> FilterByRating(List<Movie> movies, double minRating)
    {
        List<Movie> result = new List<Movie>();
        foreach (Movie m in movies)
        {
            if (m.Rating >= minRating)
            {
                result.Add(m);
            }
        }
        return result;
    }

    public static string GetTopDirector(List<Movie> movies)
    {
        Dictionary<string, int> directorsMovies = new Dictionary<string, int>();
        foreach (Movie m in movies )
        {
            if (directorsMovies.ContainsKey(m.Director))
            {
                directorsMovies[m.Director]++;
            }
            else
            {
                directorsMovies[m.Director] = 1;
            }
        }

        string TopDirector = "None";
        int max = 0;
        foreach (var r in directorsMovies)
        {
            if (r > max)
            {
                max = r.Value;
                TopDirector = r.Key;
            } 
        }
        return TopDirector;
    }
}

public static class MovieExtensions
{
    public static bool IsNewRelease(this Movie m)
    {
        return (2026-m.Year) <= 5;
    }
    public static string ToShortInfo(this Movie m)
    {
        return $"{m.Title} ({m.Year})";
    }
    
}

class Program
{
    static void Main()
    {
        var movie1 = new Movie("Toy Story 2", "Ash Brannon", 1999, 8.7, "Woody (Tom Hanks) is stolen from his home by toy dealer Al McWhiggin (Wayne Knight), leaving Buzz Lightyear (Tim Allen) and the rest of the gang to try to rescue him.");
        var movie2 = new Movie("Schindler's List", "Steven Spielberg", 1993, 9.7, "Businessman Oskar Schindler arrives in Kraków in 1939, ready to make his fortune from World War II, which has just started...");
        var movie3 = new Movie("The Lord of the Rings: The Two Towers", "Peter Jackson", 2002, 9.5);
        var movie4 = new Movie("Toy Story 2", "Ash Brannon", 1999, 8.7, "Woody (Tom Hanks) is stolen from his home by toy dealer Al McWhiggin (Wayne Knight), leaving Buzz Lightyear (Tim Allen) and the rest of the gang to try to rescue him.");

        Console.WriteLine(movie1.ToString());
        Console.WriteLine(movie2);
        Console.WriteLine(movie3);
        Console.WriteLine(movie4);

        Console.WriteLine($"movie1 Equals movie4: {movie1.Equals(movie4)}");
        Console.WriteLine($"movie1 == movie2: {movie1 == movie2}");


        var movieSet = new HashSet<Movie> {movie1, movie2, movie3, movie4};
        Console.WriteLine($"HashSet count: {movieSet.Count}");

        Console.WriteLine($"Number of Movies: {Movie.TotalMovies}");

        int descLength = movie3.Description?.Length ?? 0;
        Console.WriteLine($"Description of movie3: {descLength}");

        var allMoviesList = new List<Movie> {movie1, movie2, movie3, movie4};

        string topDir = MovieUtils.GetTopDirector(allMoviesList);
        Console.WriteLine($"Top director: {topDir}");

        Console.WriteLine($"{movie3.ToShortInfo()} is new release {movie3.IsNewRelease()}");
        Console.WriteLine($"{movie4.ToShortInfo()} is new release {movie4.IsNewRelease()}");

    }
}