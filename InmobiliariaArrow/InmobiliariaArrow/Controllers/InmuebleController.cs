using System.Collections.Generic;
using System.Linq;
using InmobiliariaArrow.Data;
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
            var inmueble = new List<InmuebleTemp>{
                new InmuebleTemp{Id = 1, Inmueble = "asdfs",
                Precio = 2143, Descripcion = "fdsfs", Estatus = "fsaf", Tipo_vivienda = "asff",},
                new InmuebleTemp{Id = 2, Inmueble = "Terreno",
                Precio = 2134, Descripcion = "fsdfa", Estatus = "asdf", Tipo_vivienda = "fsdfa",},
                new InmuebleTemp{Id = 3, Inmueble = "Campo",
                Precio = 2143, Descripcion = "safsf", Estatus = "asdfsa", Tipo_vivienda = "asdf",},
                new InmuebleTemp{Id = 4, Inmueble = "Casa",
                Precio = 4213, Descripcion = "sfsdfsd", Estatus = "asddfsaf", Tipo_vivienda = "adfasdfd",},
                new InmuebleTemp{Id = 5, Inmueble = "Casa",
                Precio = 1243, Descripcion = "fasdfaf", Estatus = "fsadfasfd", Tipo_vivienda = "sdfsadf",}
            };
            ViewBag.Inmuebles = inmueble;
            ViewData["inmueble"] = inmueble;
            ViewData["Estilo"] = "inmueble.css";
            return View();
        }

        public IActionResult Add()
        {
            var tipoPropiedades = _dbContext.TipoPropiedad.Select(tp =>
                new TipoPropiedadDto
                {
                    IdTipoPropiedad = tp.IdTipoPropiedad,
                    Nombre = tp.Nombre
                });
            ViewData["Estilo"] = "gestion_casas.css";
            ViewBag.TipoPropiedades = tipoPropiedades;
            return View();
        }
    }
}