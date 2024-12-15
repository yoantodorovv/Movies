using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movies.Models.Models.BaseEntity;

namespace Movies.Models.Models;

/// <summary>
/// struct -> default value == 0 -> NOT NULL
/// </summary>
public class Movie : BaseEntity<Guid>
{
    public Movie()
    {
        this.Genres = new HashSet<Genre>();
        this.Stars = new HashSet<Star>();
    }
    
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Name { get; set; }

    public int? ReleaseYear { get; set; }

    public string Certificate { get; set; }

    [Range(1, 500)]
    public double Runtime { get; set; }

    [Range(1, 10)]
    public double Rating { get; set; }

    [Range(0, 100)]
    public int? MetaScore { get; set; }

    [Range(0, int.MaxValue)]
    public int Votes { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? GrossIncome { get; set; }
    
    // Релации
    public ICollection<Genre> Genres { get; set; }

    [ForeignKey(nameof(Director))]
    public Guid DirectorId { get; set; }
    public Employee Director { get; set; }
    
    public ICollection<Star> Stars { get; set; }
}