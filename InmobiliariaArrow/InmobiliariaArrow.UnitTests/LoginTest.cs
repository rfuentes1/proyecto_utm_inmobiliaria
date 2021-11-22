using Xunit;
using InmobiliariaArrow.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaArrow.UnitTests
{
    public class LoginTest
    {
       [Fact]
       public void Login_LoginValido_AbreVistaAdmin()
       {
            //Arrange
            var loginController = new LoginController();
            
            //Act
            var vista =
                (RedirectToActionResult)loginController.Index(usuario: "rocio", password: "rocio123");
            //Assert
            Assert.Equal("Inmueble",vista.ControllerName);
            Assert.Equal("Index",vista.ActionName);
       }

       [Fact]
       public void Login_LoginInvalido_RegresaAlLogin()
       {
           //Arrange
           var loginController = new LoginController();
            
           //Act
           var vista =
               loginController.Index(usuario: "USUARIO NO VALIDO", password: "XXXXXXX") as ViewResult;
           //Assert
           Assert.IsType<ViewResult>(vista); //validar que se una vista
           Assert.True((bool)vista.ViewData["LoginFallido"]); //que sea igual a verdadero
           
       }
       
       [Fact]
       public void Login_NollenarAlgunCampo_RegresaAlLogin()
       {
           //Arrange
           var loginController = new LoginController();
            
           //Act
           var vista =
               loginController.Index(usuario: null, password: null) as ViewResult;
           //Assert
           Assert.IsType<ViewResult>(vista); //validar que se una vista
           Assert.True((bool)vista.ViewData["LoginFallido"]); //que sea igual a verdadero
           
       }
    }
}