using FitFoods.Domain;
using FitFoods.Domain.Interface.Repositories;
using FitFoods.Domain.Interface.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FitFoods.Service.Test
{
    public class InvoiceServiceTest
    {
        [Fact]
        public void shouldCreateNewInvoice()
        {
            List<Snack> result = new List<Snack>();
            result.Add(new Snack(1, "Hamburguer", 12));

            Mock<ISnackRepository> snackRepoMock = new Mock<ISnackRepository>();
            snackRepoMock.Setup(x => x.ListAll()).Returns(result);

            ISnackService snackService = new SnackService(snackRepoMock.Object);
            
            List<Snack> retorno = snackService.ListAll();
            
            IInvoiceService invoiceService = new InvoiceService();
            var newInvoice = invoiceService.createInvoice(retorno);

            Assert.Contains(retorno[0], newInvoice.snacks);
        }

    }
}
