using FitFoods.Domain.Interface.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitFoods.Domain.Test
{
    public class kitchenTest
    {
        [Fact]
        public void ShouldCreateKitchen()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            IInvoice invoice = new Invoice(snacks);

            kitchen kitchen = new kitchen();

            Assert.Same(kitchen.GetType(), typeof(kitchen));
        }

        [Fact]
        public void ShouldAddInvoiceToQueue()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));

            IInvoice invoice = new Invoice(snacks);

            kitchen kitchen = new kitchen();

            kitchen.AddInvoice(invoice);
            kitchen.AddInvoice(invoice);
            kitchen.AddInvoice(invoice);
            kitchen.AddInvoice(invoice);

            List<Snack> snacksToQueue = new List<Snack>();
            snacksToQueue.Add(new Snack(2, "Juice", 15));

            IInvoice invoiceToQueue = new Invoice(snacksToQueue);

            kitchen.AddInvoice(invoiceToQueue);

            Assert.Same(kitchen.GetNextInvoice(), invoiceToQueue);
        }

        [Fact]
        public void ShouldFinishedTheLastInvoiceSented()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 90000000));

            IInvoice invoice = new Invoice(snacks);

            kitchen kitchen = new kitchen();

            kitchen.AddInvoice(invoice);
            kitchen.AddInvoice(invoice);
            kitchen.AddInvoice(invoice);

            List<Snack> snacksToFinish = new List<Snack>();
            snacksToFinish.Add(new Snack(2, "Juice", 20));

            IInvoice invoiceToFinish = new Invoice(snacksToFinish);

            kitchen.AddInvoice(invoiceToFinish);

            Assert.Same(kitchen.GetDelivered(), invoiceToFinish);
        }

    }
}
