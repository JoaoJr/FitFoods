using FitFoods.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.States
{
    public class Delivered : IInvoiceState
    {
        public IInvoiceState LastAcceptableState => new Finished();
    }
}
