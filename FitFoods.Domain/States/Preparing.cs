using FitFoods.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.States
{
    public class Preparing : IInvoiceState
    {
        public IInvoiceState LastAcceptableState => null;
    }
}
