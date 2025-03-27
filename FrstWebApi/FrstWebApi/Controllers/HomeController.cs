using Microsoft.AspNetCore.Mvc;

namespace FrstWebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ListOfStudents = new StudentController().GetStudents();
            return View(ListOfStudents);
        }
    }
}
