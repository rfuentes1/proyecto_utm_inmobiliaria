using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using InmobiliariaArrow.Models;

namespace InmobiliariaArrow.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
        }

        public IActionResult Index()
        {
            ViewData["Estilo"] = "login.css";
            return View();
        }
    }
}