using FitFoods.Domain;
using FitFoods.Domain.Interface;
using FitFoods.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Repository
{
    public class SnackRepository : ISnackRepository
    {
        public List<Snack> ListAll()
        {
            //TO-DO ler o json para gerar os itens posteriormente.
            //Resolvi não fazer agora pois acho que os outros pontos são mais prioritários.
            List<Snack> snacks = new List<Snack>();
            snacks.Add(new Snack(1, "Hamburguer", 10));
            snacks.Add(new Snack(2, "Juice", 15));
            snacks.Add(new Snack(3, "French Fries", 1));

            return snacks;
        }
    }
}
