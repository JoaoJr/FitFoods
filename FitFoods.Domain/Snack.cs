using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain
{
    public class Snack
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Time { get; private set; }

        public Snack(int id, string name, decimal time)
        {
            if (id <= 0 || String.IsNullOrEmpty(name) || time <=0)
            {
                throw new Exception("Snack must exists!");
            }

            this.Id = id;
            this.Name = name;
            this.Time = time;
        }
    }
}
