using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InmobiliariaArrow.Models;
using InmobiliariaArrow.Data;

namespace InmobiliariaArrow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //1. Consultar de la base de datos tod-os los inmuebles
            var inmueblesDto = _dbContext.Inmuebles
                //se transforma una entidad inmuebñe a un dto de inmueble
                .Select(inmueble => new InmuebleDto
                {
                    Titulo = inmueble.Titulo,
                    Precio = inmueble.Precio,
                    Operacion = inmueble.Operacion,
                    NumBanios = inmueble.NumBanios,
                    NumRecamaras = inmueble.NumRecamaras,
                    Superficie = inmueble.Superficie
                });
            // 2. Meter esa lista de inmuebles al viewbag para que se puedan acceder en el view desde razor
            ViewBag.Inmuebles = inmueblesDto;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
