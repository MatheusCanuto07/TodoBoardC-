using Microsoft.AspNetCore.Mvc;

namespace TODO.Controllers
{
    public class BoardsController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
