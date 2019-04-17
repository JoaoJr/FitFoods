using FitFoods.Domain.Interface;
using FitFoods.Domain.Interface.Domain;
using FitFoods.Domain.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain
{
    public class Invoice: IInvoice
    {
        public IInvoiceState CurrentState;

        public List<Snack> snacks { get; private set; }

        public Invoice(List<Snack> snacks)
        {
            this.snacks = snacks;
        }

        public void Prepare()
        {
            if (CurrentState == null)
            {
                CurrentState = new Preparing();
            }
        }

        public void Finish()
        {
            var NextState = new Finished();
            DefineNextState(NextState);
        }

        public void Delivery()
        {
            var NextState = new Delivered();
            DefineNextState(NextState);
        }

        public IInvoiceState GetCurrentState()
        {
            return this.CurrentState;
        }

        private void DefineNextState(IInvoiceState NextState)
        {
            if (NextState.LastAcceptableState.GetType().Equals(CurrentState.GetType()))
            {
                CurrentState = NextState;
            }
            else
            {
                throw new Exception("problem with workflow in kitchen");
            }
        }

        public void AddSnack(List<Snack> snacks)
        {
            foreach (var itemSnacks in snacks)
            {
                this.snacks.Add(itemSnacks);
            }
        }

    }
}
