using FitFoods.Domain.Interface.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FitFoods.Domain
{
    public class kitchen
    {
        Queue<IInvoice> queueEntry = new Queue<IInvoice>();
        Queue<IInvoice> queueOut = new Queue<IInvoice>();
        int invoicesPreparing = 0;

        public kitchen()
        {
        }

        public void AddInvoice(IInvoice invoice)
        {
            if (queueEntry.Count.Equals(0) && invoicesPreparing < 4)
            {
                this.StartPrepare(invoice);
            }
            else
            {
                queueEntry.Enqueue(invoice);
            }
        }

        public IInvoice GetNextInvoice()
        {
            if (queueEntry.Count > 0)
            {
                return queueEntry.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public IInvoice GetDelivered()
        {
            if (queueOut.Count > 0)
            {
                return queueEntry.Peek();
            }
            else
            {
                return null;
            }
        }

        private void StartPrepare(IInvoice invoice)
        {
            invoicesPreparing = invoicesPreparing + 1;
            invoice.Prepare();

            ThreadPool.QueueUserWorkItem(PassTime, invoice);
        }

        private void PassTime(object invoice)
        {
            IInvoice invoiceStarted = (IInvoice)invoice;
            foreach (var item in invoiceStarted.snacks)
            {
                Thread.Sleep(Decimal.ToInt32(item.Time));
            }
            invoiceStarted.Finish();
            invoicesPreparing = invoicesPreparing - 1;
            StartPrepare(GetNextInvoice());
            queueOut.Enqueue(invoiceStarted);
            invoiceStarted.Delivery();
        }
    }
}
