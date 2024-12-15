using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Models;
using Movies.Models.Models.Identity;

namespace Movies.Infrastructure;

public class MovieDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public MovieDbContext()
    {
        
    }
    
    // DbSet -> Tables in DB
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Star> Stars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=MoviesDb;User Id=sa;Password=Password123$;");
        
        base.OnConfiguring(optionsBuilder);
    }
}