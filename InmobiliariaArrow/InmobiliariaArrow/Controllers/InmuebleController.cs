using System.Collections.Generic;
using System.Linq;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Entities;
using InmobiliariaArrow.Models;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaArrow.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public InmuebleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var inmueblesDTO = _dbContext.Inmuebles
            .Select(inmueble => new InmuebleDto
            {
                Titulo = inmueble.Titulo,
                Precio = inmueble.Precio,
                Operacion = inmueble.Operacion, 
                Descripcion = inmueble.Descripcion,
                Superficie = inmueble.Superficie
            });
            ViewBag.Inmuebles = inmueblesDTO;
            ViewData["Estilo"] = "inmueble.css";
            return View();
        }

        public IActionResult Add()
        {
            var tipoPropiedades = _dbContext.TipoPropiedad
                .Select(tp =>
                new TipoPropiedadDto
                {
                    IdTipoPropiedad = tp.IdTipoPropiedad,
                    Nombre = tp.Nombre
                });
            ViewData["Estilo"] = "gestion_casas.css";
            ViewBag.TipoPropiedades = tipoPropiedades;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(InmuebleDto inmuebleDto)
        {
            var inmueble =
                new Inmueble
                {
                    Titulo = inmuebleDto.Titulo,
                    Descripcion = inmuebleDto.Descripcion,
                    Precio = inmuebleDto.Precio,
                    EstaDisponible = inmuebleDto.EstaDisponible,
                    Operacion = inmuebleDto.Operacion,
                    TipoPropiedadId = inmuebleDto.IdTipoPropiedad,
                    NumBanios = inmuebleDto.NumBanios,
                    NumRecamaras = inmuebleDto.NumRecamaras,
                    Superficie = inmuebleDto.Superficie
                };
            _dbContext.Inmuebles.Add(inmueble);
            _dbContext.SaveChanges();
            return  RedirectToAction("Index");
        }
    }
}