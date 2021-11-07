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
        private static readonly string CarpetaFotos = $"{Directory.GetCurrentDirectory()}/wwwroot/Inmueble/fotos/";

        public InmuebleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var inmueblesDTO = _dbContext.Inmuebles
            .Select(inmueble => new InmuebleDto
            {
                Id = inmueble.IdInmueble,
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
             var inmueble = _dbContext.Inmuebles.Find(id);
             var inmuebleOrigen = new InmuebleDto
                {
                    Id = inmueble.IdInmueble,
                    Titulo = inmueble.Titulo,
                    Descripcion = inmueble.Descripcion,
                    Precio = inmueble.Precio,
                    EstaDisponible = inmueble.EstaDisponible,
                    Operacion = inmueble.Operacion,
                    IdTipoPropiedad = inmueble.TipoPropiedadId,
                    NumBanios = inmueble.NumBanios,
                    NumRecamaras = inmueble.NumRecamaras,
                    Superficie = inmueble.Superficie,
                    Direccion = inmueble.Direccion
                };
             ViewBag.Original = inmuebleOrigen;
             var tipoPropiedades = _dbContext.TipoPropiedad
                 .Select(tp =>
                     new TipoPropiedadDto
                     {
                         IdTipoPropiedad = tp.IdTipoPropiedad,
                         Nombre = tp.Nombre
                     });
             ViewBag.TipoPropiedades = tipoPropiedades;
             ViewData["Estilo"] = "gestion_casas.css";
            return View(inmuebleOrigen);
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
                    Superficie = inmuebleDto.Superficie,
                    Direccion = inmuebleDto.Direccion
                };
            var inmuebleGuardado = _dbContext.Inmuebles.Add(inmueble).Entity;
            _dbContext.SaveChanges();
            var idInmueble = inmuebleGuardado.IdInmueble.ToString();
            GuardarFotosEnCarpeta(fotos, idInmueble);
            return  RedirectToAction("Index");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InmuebleDto inmuebleDto, List<IFormFile> fotos)
        {
            var inmueble =
                new Inmueble
                {
                    IdInmueble = inmuebleDto.Id,
                    Titulo = inmuebleDto.Titulo,
                    Descripcion = inmuebleDto.Descripcion,
                    Precio = inmuebleDto.Precio,
                    EstaDisponible = inmuebleDto.EstaDisponible,
                    Operacion = inmuebleDto.Operacion,
                    TipoPropiedadId = inmuebleDto.IdTipoPropiedad,
                    NumBanios = inmuebleDto.NumBanios,
                    NumRecamaras = inmuebleDto.NumRecamaras,
                    Superficie = inmuebleDto.Superficie,
                    Direccion = inmuebleDto.Direccion
                };
            _dbContext.Inmuebles.Update(inmueble);
            _dbContext.SaveChanges();
            GuardarFotosEnCarpeta(fotos, inmuebleDto.Id.ToString());
            return  RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(int inmuebleId)
        {
            var inmuebleABorrar = _dbContext.Inmuebles.Find(inmuebleId);
            _dbContext.Inmuebles.Remove(inmuebleABorrar);
            _dbContext.SaveChanges();
            if (Directory.Exists($"{CarpetaFotos}/{inmuebleId}"))
                Directory.Delete($"{CarpetaFotos}/{inmuebleId}", true);
            return RedirectToAction("Index");
        }
        
        private static void GuardarFotosEnCarpeta(List<IFormFile> fotos, string idInmueble)
        {
            if (fotos.Count < 1)
                return;
            var ruta = $"{CarpetaFotos}/{idInmueble}";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            foreach (var file in fotos)
            {
                var fotoId = Convert.ToString(Guid.NewGuid());
                var rutaFoto =
                    new PhysicalFileProvider(ruta).Root + $"{fotoId}.jpg";
                using var fs = System.IO.File.Create(rutaFoto);
                file.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}