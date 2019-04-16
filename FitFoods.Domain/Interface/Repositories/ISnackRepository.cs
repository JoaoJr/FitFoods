using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Domain.Interface.Repositories
{
    public interface ISnackRepository
    {
        List<Snack> ListAll();
    }
}
