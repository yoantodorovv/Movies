using System.ComponentModel.DataAnnotations;
using Movies.Models.Enums;
using Movies.Models.Models.BaseEntity;

namespace Movies.Models.Models;

public class Employee : BaseEntity<Guid>
{
    public Employee()
    {
        this.Movies = new HashSet<Movie>();
    }
    
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; }
    
    // Релации
    public ICollection<Movie> Movies { get; set; }
}