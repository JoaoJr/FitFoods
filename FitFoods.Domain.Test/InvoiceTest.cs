using FitFoods.Domain.States;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitFoods.Domain.Test
{
    public class InvoiceTest
    {
        [Fact]
        public void ShouldCreateInvoiceWithHamburguer()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            Assert.Equal(invoice.snacks[0].Name, snacks[0].Name);
        }

        [Fact]
        public void ShouldAddSnackToInvoice()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            List<Snack> snacksAdd = new List<Snack>();
            snacks.Add(new Snack(1, "Juice", 10));
            invoice.AddSnack(snacksAdd);

            Assert.Equal(invoice.snacks[0].Name, snacks[0].Name);
            Assert.Equal(invoice.snacks[1].Name, snacks[1].Name);
        }

        [Fact]
        public void ShouldChangeStateToPrepare()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            invoice.Prepare();
            Assert.Equal(invoice.CurrentState.LastAcceptableState, new Preparing().LastAcceptableState);
        }

        [Fact]
        public void ShouldChangeStateToFinish()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            invoice.Prepare();
            invoice.Finish();
            Assert.Equal(invoice.CurrentState.LastAcceptableState.GetType(), new Finished().LastAcceptableState.GetType());
        }

        [Fact]
        public void ShouldChangeStateToDelivered()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            invoice.Prepare();
            invoice.Finish();
            invoice.Delivery();
            Assert.Equal(invoice.CurrentState.LastAcceptableState.GetType(), new Delivered().LastAcceptableState.GetType());
        }

        [Fact]
        public void ShouldExceptionWhenChangeStateFromPrepareToDelivery()
        {
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            Invoice invoice = new Invoice(snacks);

            invoice.Prepare();
            Assert.Throws<Exception>(() => invoice.Delivery());
        }
    }
}
