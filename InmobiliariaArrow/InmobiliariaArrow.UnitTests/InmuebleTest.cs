using InmobiliariaArrow.Controllers;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InmobiliariaArrow.UnitTests
{
    public class InmuebleTest
    {
        [Fact]
        public void EliminarInmueble_RegistroBorrado()
        {
            // Arrange
            var baseDeDatos = ObtenerBaseDatosConRegistro();
            var inmuebleController = new InmuebleController(baseDeDatos);
            
            // Act
            inmuebleController.Delete(1);
            
            // Assert
            Assert.Null(baseDeDatos.Inmuebles.Find(1));
        }

        private static ApplicationDbContext ObtenerBaseDatosConRegistro()
        {
            var opciones =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("arrow_en_memoria_bd").Options;
            
            
            var dbContext = new ApplicationDbContext(opciones);
            
            
            dbContext.TipoPropiedad.Add(
                new TipoPropiedad { IdTipoPropiedad = 1, Nombre = "Casa" }
            );
            dbContext.Inmuebles.Add(new Inmueble
            {
                Titulo = "Casa de prueba",
                Descripcion = "Descripcion prueba",
                Precio = 17000,
                EstaDisponible = true,
                Operacion = "Renta",
                TipoPropiedadId = 1,
                NumBanios = "4",
                NumRecamaras = "3",
                Superficie = "2000",
                Direccion = "Altabrisa"
            });
            return dbContext;
        }
    }
}