using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
