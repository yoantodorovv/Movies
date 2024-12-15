using Movies.Infrastructure;
using Movies.Infrastructure.Repository;
using Movies.Models.Models;
using Movies.Services.ReaderService;

namespace Movies.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new MovieDbContext();
        
        var movieRepository = new Repository<Movie>(dbContext);
        var genreRepository = new Repository<Genre>(dbContext);
        var starRepository = new Repository<Star>(dbContext);
        var employeeRepository = new Repository<Employee>(dbContext);
        
        var readerService = new ReaderService(
            movieRepository,
            genreRepository,
            starRepository,
            employeeRepository,
            dbContext);
        
        readerService.SeedDatabase();
    }
}