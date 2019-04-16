using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitFoods.Domain.Test
{
    public class SnackTest
    {
        [Fact]
        public void ShouldCreateSnack()
        {
            string food = "Hamburguer";
            int id = 1;
            decimal time = 3;

            Snack snack = new Snack(id, food, time);

            Assert.Equal(snack.Name, food);
        }

        [Fact]
        public void ShouldntCreateSnackNull()
        {
            Assert.Throws<Exception>(() => new Snack(99, null, 99));
        }
    }
}
