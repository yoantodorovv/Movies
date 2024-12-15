using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Controllers.Home;

public class HomeController : Controller
{
    public HomeController()
    {
        
    }
    
    // localhost:5000/Home/Index || localhost:5000/
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}