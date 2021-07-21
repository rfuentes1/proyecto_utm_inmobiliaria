﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaArrow.Controllers
{
    public class DetalleCasaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Estilo"] = "detalle_casa.css";
            return View();
        }
    }
}
