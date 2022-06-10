using ChapterSenai.Controllers;
using ChapterSenai.Interfaces;
using ChapterSenai.Models;
using ChapterSenai.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestXUnit.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            //Arrange - Preparação
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosLogin = new LoginViewModel();

            dadosLogin.Email = "email@email.com";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);

            //Act - Ação
            var resultado = controller.Login(dadosLogin);

            //Assert - verificação
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }
        [Fact]
        public void LoginController_Retornar_Token()
        {
            //Arrange - Preparação
            Usuario usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "email@email.com";
            usuarioRetorno.Senha = "123";
            usuarioRetorno.Tipo = "0";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetorno);

            string issuerValidacao = "chapter.webapi";

            LoginViewModel dadosLogin = new LoginViewModel();
            dadosLogin.Email = "email@email.com";
            dadosLogin.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);

            //Act - Ação
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosLogin);

            string token = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(token);

            //Assert - verificação
            Assert.Equal(issuerValidacao, tokenJwt.Issuer);

        }
    }
}
