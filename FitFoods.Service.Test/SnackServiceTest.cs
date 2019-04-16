using FitFoods.Domain;
using FitFoods.Domain.Interface.Repositories;
using FitFoods.Domain.Interface.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitFoods.Service.Test
{
    public class SnackServiceTest
    {
        [Fact]
        public void ShouldReturnSnack()
        {
            List<Snack> result = new List<Snack>();
            result.Add(new Snack(1, "Hamburguer", 12));

            Mock<ISnackRepository> snackRepoMock = new Mock<ISnackRepository>();
            snackRepoMock.Setup(x => x.ListAll()).Returns(result);

            ISnackService service = new SnackService(snackRepoMock.Object);

            List<Snack> retorno = service.ListAll();

            Assert.Equal(result[0].Name, retorno[0].Name);
            Assert.True(retorno.Count == 1);

            snackRepoMock.VerifyAll();

        }
    }
}
