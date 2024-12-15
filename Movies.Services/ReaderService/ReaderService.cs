using System.Globalization;
using CsvHelper;
using Movies.Infrastructure;
using Movies.Infrastructure.Repository.Interface;
using Movies.Models.Enums;
using Movies.Models.Models;
using Movies.Services.ReaderService.Dto;

namespace Movies.Services.ReaderService;

public class ReaderService
{
    // Dependency Injection
    private readonly IRepository<Movie> _movieRepository;
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<Star> _starRepository;
    private readonly IRepository<Employee> _employeeRepository;
    
    private readonly MovieDbContext _dbContext;

    public ReaderService(
        IRepository<Movie> movieRepository,
        IRepository<Genre> genreRepository,
        IRepository<Star> starRepository,
        IRepository<Employee> employeeRepository,
        MovieDbContext dbContext)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _starRepository = starRepository;
        _employeeRepository = employeeRepository;

        _dbContext = dbContext;
    }

    // DB Seed (Inserting data in the DataBase)
    public void SeedDatabase()
    {
        var records = ReadMovies();
        
        var moviesDict = new Dictionary<string, Movie>();
        var genresDict = new Dictionary<string, Genre>(); 
        var starsDict = new Dictionary<string, Star>();
        var employeesDict = new Dictionary<string, Employee>();

        foreach (var record in records)
        {
            genresDict = AddGenres(genresDict, record);
            starsDict = AddStars(starsDict, record);
            employeesDict = AddDirector(employeesDict, record);
            
            var isReleaseYearAvailable = int.TryParse(record.Released_Year, out int releaseYear);
            var isGrossAvailable = decimal.TryParse(record.Gross, out decimal grossIncome);
            var isMetaScoreAvailable = int.TryParse(record.Meta_score, out int metaScore);
            
            var movie = new Movie()
            {
                Name = record.Series_Title,
                ReleaseYear = isReleaseYearAvailable ? releaseYear : null,
                Certificate = record.Certificate,
                Runtime = record.Runtime,
                Rating = record.IMDB_Rating,
                MetaScore = isMetaScoreAvailable ? metaScore : null,
                Votes = record.No_of_Votes,
                GrossIncome = isGrossAvailable ? grossIncome : null,
            };
            
            AddToDictionary<Movie>(ref moviesDict, movie.Name, movie);
        }
        
        // _dbContext.AddRange(genresDict.Values);
        // _genreRepository.SaveChanges();
        //
        // _dbContext.AddRange(starsDict.Values);
        // _starRepository.SaveChanges();
        //
        // _dbContext.AddRange(employeesDict.Values);
        // _employeeRepository.SaveChanges();
        //
        // _movieRepository.AddRange(moviesDict.Values);
        // _movieRepository.SaveChanges();
        
        _dbContext.SaveChanges();
    }

    private static Dictionary<string, Star> AddStars(Dictionary<string, Star> stars, MovieReaderDto record)
    {
        var star1 = new Star()
        {
            Name = record.Star1,
            Priority = StarPriorityEnum.FirstStar,
        };
            
        var star2 = new Star()
        {
            Name = record.Star2,
            Priority = StarPriorityEnum.SecondStar,
        };
            
        var star3 = new Star()
        {
            Name = record.Star3,
            Priority = StarPriorityEnum.ThirdStar,
        };
            
        var star4 = new Star()
        {
            Name = record.Star4,
            Priority = StarPriorityEnum.FourthStar,
        };
        
        AddToDictionary<Star>(ref stars, star1.Name, star1);
        AddToDictionary<Star>(ref stars, star2.Name, star2);
        AddToDictionary<Star>(ref stars, star3.Name, star3);
        AddToDictionary<Star>(ref stars, star4.Name, star4);

        return stars;
    }
    private static Dictionary<string, Genre> AddGenres(Dictionary<string, Genre> genres, MovieReaderDto record)
    {
        var mainGenre = new Genre()
        {
            Name = record.Genre,
            Priority = GenrePriorityEnum.MainGenre,
        };
        var firstSubgenre = new Genre()
        {
            Name = record.Subgenre,
            Priority = GenrePriorityEnum.FirstSubgenre,
        };
        var secondSubgenre = new Genre()
        {
            Name = record.Subgenre1,
            Priority = GenrePriorityEnum.SecondSubgenre,
        };
        
        AddToDictionary<Genre>(ref genres, mainGenre.Name, mainGenre);
        AddToDictionary<Genre>(ref genres, firstSubgenre.Name, firstSubgenre);
        AddToDictionary<Genre>(ref genres, secondSubgenre.Name, secondSubgenre);

        return genres;
    }

    private static Dictionary<string, Employee> AddDirector(Dictionary<string, Employee> directors, MovieReaderDto record)
    {
        var director = new Employee()
        {
            Name = record.Director,
        };
        
        AddToDictionary<Employee>(ref directors, director.Name, director);

        return directors;
    }
    
    private static void AddToDictionary<T>(ref Dictionary<string, T> dict, string key, T model)
    {
        if (!dict.ContainsKey(key) && !string.IsNullOrEmpty(key))
        {
            dict.Add(key, model);
        }
    }
    
    private static List<MovieReaderDto> ReadMovies()
    {
        // DO NOT DO! -> local path
        var moviesPath = "/Users/yoantodorov/RiderProjects/MoviesSol/Movies.Services/ReaderService/Data/movies_data.csv";
        
        // DO! -> relative path
        // var moviesPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "movies_data.csv");
        
        using var reader = new StreamReader(moviesPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csv
            .GetRecords<MovieReaderDto>()
            .ToList();
    }
}