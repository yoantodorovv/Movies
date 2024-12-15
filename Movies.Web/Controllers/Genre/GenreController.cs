using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure;
using Movies.Models.Enums;
using Movies.Web.Dtos.Genre;

namespace Movies.Web.Controllers.Genre;

public class GenreController : Controller
{
    private readonly MovieDbContext _dbContext;
    
    public GenreController(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // localhost:5000/Genre/Catalog
    public IActionResult Catalog()
    {
        var genres = _dbContext.Genres.ToList();
        var genresCatalog = new List<GenreCatalogDto>();

        foreach (var genre in genres)
        {
            genresCatalog.Add(new GenreCatalogDto
            {
                GenreName = genre.Name,
                Priority = genre.Priority.ToString()
            });
        }
        
        return View("Catalog", genresCatalog);
    }
    
    // localhost:5000/Genre/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(CreateGenreDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var genre = new Models.Models.Genre()
        {
            Name = model.Name,
            Priority = Enum.Parse<GenrePriorityEnum>(model.Priority)
        };

        _dbContext.Genres.Add(genre);
        _dbContext.SaveChanges();
        
        return RedirectToAction("Catalog");
    }
}