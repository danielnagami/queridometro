using Microsoft.AspNetCore.Mvc;
using Queridometro.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.WebApp.Controllers
{
    [Route("main")]
    public class QueridometroController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
