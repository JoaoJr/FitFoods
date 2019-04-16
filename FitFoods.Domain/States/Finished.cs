using FitFoods.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.States
{
    public class Finished : IInvoiceState
    {
        public IInvoiceState LastAcceptableState => new Preparing();
    }
}
