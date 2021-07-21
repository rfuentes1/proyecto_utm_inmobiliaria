using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaArrow.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Estilo"] = "login.css";
            return View();
        }
    }
}