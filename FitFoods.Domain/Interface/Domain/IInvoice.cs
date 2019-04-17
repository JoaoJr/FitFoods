using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.Interface.Domain
{
    public interface IInvoice
    {
        List<Snack> snacks { get; }

        void Prepare();

        void Finish();

        void Delivery();

        IInvoiceState GetCurrentState();

        void AddSnack(List<Snack> snacks);
    }
}
