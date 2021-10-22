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
        public IActionResult Login(string usuario, string password)
        {
            if (usuario == "rocio" && password == "rocio123")
            {
                return RedirectToAction("Index", "Inmueble");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}