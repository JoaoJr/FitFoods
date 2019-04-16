using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.Interface
{
    public interface IInvoiceState
    {
        IInvoiceState LastAcceptableState { get; }
    }
}
