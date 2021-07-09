using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InmobiliariaArrow.Models;
//using InmobiliariaArrow.Models;

namespace InmobiliariaArrow.Controllers
{
    public class InmuebleController : Controller
    {
        public InmuebleController()
        {
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
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}