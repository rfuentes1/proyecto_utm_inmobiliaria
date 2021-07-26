using System.Diagnostics;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Entities;
using InmobiliariaArrow.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaArrow.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RegistroController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Estilo"] = "registro.css";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AdministradorDto administradorDto)
        {
            var administrador =
                new Administrador
                {
                    Nombres = administradorDto.Nombres,
                    Apellidos = administradorDto.Apellidos,
                    Correo = administradorDto.Correo,
                    Telefono = administradorDto.Telefono,
                    Pais = administradorDto.Pais,
                    Ciudad = administradorDto.Ciudad,
                    Estado = administradorDto.Estado,
                    Usuario = administradorDto.Usuario,
                    Password = administradorDto.Password
                };
                _dbContext.Administradores.Add(administrador);
                _dbContext.SaveChanges();
                return RedirectToAction("Index","Login");
        }
    }
}