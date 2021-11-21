using System;
using InmobiliariaArrow.Controllers;
using InmobiliariaArrow.Data;
using InmobiliariaArrow.Entities;
using InmobiliariaArrow.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InmobiliariaArrow.UnitTests
{
    public class InmuebleTest
    {
        [Fact]
        public void AgregarInmueble_ConTodosLosCamposRequeridos_RegistroCreadoEnBd()
        {
            // Arrange
            var baseDeDatos = CrearBaseDatosVacia();
            var inmuebleController = new InmuebleController(baseDeDatos);

            // Act
            inmuebleController.Add(new InmuebleDto
            {
                Titulo = "Nueva Casa",
                Descripcion = "Descripcion prueba",
                Precio = 17000,
                EstaDisponible = true,
                Operacion = "Renta",
                IdTipoPropiedad = 1, // Casa
                NumBanios = "4",
                NumRecamaras = "3",
                Superficie = 2000,
                Direccion = "Altabrisa"
            }, null);

            // Assert
            Assert.Equal("Nueva Casa", baseDeDatos.Inmuebles.Find(1).Titulo);
        }

        [Fact]
        public void AgregarInmueble_SinCamposRequeridos_LanzaExcepcion()
        {
            // Arrange
            var baseDeDatos = CrearBaseDatosVacia();
            var inmuebleController = new InmuebleController(baseDeDatos);

            // Act
            var excepcionAtrapada = Assert.Throws<ArgumentException>(() =>
                inmuebleController.Add(new InmuebleDto { Precio = 17000 }, null)
            );

            // Assert
            Assert.Equal("Todos los campos de inmueble son requeridos", excepcionAtrapada.Message);
        }

        [Fact]
        public void EliminarInmueble_RegistroBorrado()
        {
            // Arrange
            var baseDeDatos = CrearBaseDatosVacia();
            baseDeDatos.Inmuebles.Add(new Inmueble
            {
                Titulo = "Casa de prueba",
                Descripcion = "Descripcion prueba",
                Precio = 17000,
                EstaDisponible = true,
                Operacion = "Renta",
                TipoPropiedadId = 1,
                NumBanios = "4",
                NumRecamaras = "3",
                Superficie = 2000,
                Direccion = "Altabrisa"
            });
            var inmuebleController = new InmuebleController(baseDeDatos);

            // Act
            inmuebleController.Delete(1);

            // Assert
            Assert.Null(baseDeDatos.Inmuebles.Find(1));
        }

        private ApplicationDbContext CrearBaseDatosVacia()
        {
            // Crear la base de datos en memoria con las tablas inmueble y tipo_inmueble
            var dbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            // Agregar los tipos de inmueble por default
            dbContext.TipoPropiedad.Add(new TipoPropiedad { IdTipoPropiedad = 1, Nombre = "Casa" });
            dbContext.TipoPropiedad.Add(new TipoPropiedad { IdTipoPropiedad = 2, Nombre = "Departamento" });
            return dbContext;
        }
    }
}