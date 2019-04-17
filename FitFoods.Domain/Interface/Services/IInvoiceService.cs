using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.Interface.Services
{
    public interface IInvoiceService
    {
        Invoice createInvoice(List<Snack> snacks);
    }
}
