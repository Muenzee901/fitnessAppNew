using Microsoft.AspNetCore.Mvc;

namespace fitnessAppNew.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
