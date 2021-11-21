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

        [HttpPost]
        public IActionResult Index(string usuario, string password)
        {
            if (usuario == "rocio" && password == "rocio123")
            {
                ViewBag.LoginFallido = false;
                return RedirectToAction("Index", "Inmueble");
            }
            ViewBag.LoginFallido = true;
            ViewData["Estilo"] = "login.css";
            return View();
        }
        
    }
}