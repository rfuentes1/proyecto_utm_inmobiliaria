using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Entities;
using InmobiliariaArrow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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
        public IActionResult Add(InmuebleDto inmuebleDto, List<IFormFile> fotos)
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
            var inmuebleGuardado = _dbContext.Inmuebles.Add(inmueble).Entity;
            _dbContext.SaveChanges();
            var idInmueble = inmuebleGuardado.IdInmueble.ToString();
            GuardarFotosEnCarpeta(fotos, idInmueble);
            return  RedirectToAction("Index");
        }

        private static void GuardarFotosEnCarpeta(List<IFormFile> fotos, string idInmueble)
        {
            if (fotos.Count < 1)
                return;
            var ruta = $@"{Directory.GetCurrentDirectory()}/wwwroot/Inmueble/fotos/{idInmueble}";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            foreach (var file in fotos)
            {
                var fotoId = Convert.ToString(Guid.NewGuid());
                var rutaFoto =
                    new PhysicalFileProvider(ruta).Root + $"{fotoId}.jpg";
                using (FileStream fs = System.IO.File.Create(rutaFoto))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
        }
    }
}