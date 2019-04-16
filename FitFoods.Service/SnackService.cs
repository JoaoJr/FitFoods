using FitFoods.Domain;
using FitFoods.Domain.Interface.Repositories;
using FitFoods.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitFoods.Service
{
    public class SnackService : ISnackService
    {
        private ISnackRepository _snackRepository; 

        public SnackService(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public List<Snack> ListAll()
        {
            return _snackRepository.ListAll();
        }
    }
}
