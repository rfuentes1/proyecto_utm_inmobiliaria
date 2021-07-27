using System.Diagnostics;
using System.IO;
using System.Linq;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
                    Superficie = inmueble.Superficie,
                    VistaPreviaFoto = obtenerVistaPrevia(inmueble.IdInmueble)
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

        private static string obtenerVistaPrevia(int id)
        {
            var ruta = $@"{Directory.GetCurrentDirectory()}/wwwroot/Inmueble/fotos/{id.ToString()}/";
            var di = new DirectoryInfo(ruta);
            string firstFileName =
                di.GetFiles("*.jpg")
                    .Select(fi => fi.Name)
                    .FirstOrDefault();
            return $@"Inmueble/fotos/{id.ToString()}/{firstFileName}";
        }
    }
}
