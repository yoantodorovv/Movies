using System.ComponentModel.DataAnnotations;
using Movies.Models.Enums;
using Movies.Models.Models.BaseEntity;

namespace Movies.Models.Models;

public class Star : BaseEntity<int>
{
    public Star()
    {
        this.Movies = new HashSet<Movie>();
    }
    
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; }

    public StarPriorityEnum Priority { get; set; }
    
    // Релации
    public ICollection<Movie> Movies { get; set; }
}