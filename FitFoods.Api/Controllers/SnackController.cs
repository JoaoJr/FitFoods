using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitFoods.Domain;
using FitFoods.Domain.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        private ISnackService service;

        public SnackController(ISnackService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ActionResult<List<Snack>> Get()
        {
            return service.ListAll();
        }

    }
}
