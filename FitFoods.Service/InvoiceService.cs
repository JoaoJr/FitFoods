using FitFoods.Domain;
using FitFoods.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Service
{
    public class InvoiceService: IInvoiceService
    {
        public Invoice createInvoice(List<Snack> snacks)
        {
            return new Invoice(snacks);
        }
    }
}
