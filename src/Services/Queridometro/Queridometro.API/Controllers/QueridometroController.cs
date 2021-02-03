using Microsoft.AspNetCore.Mvc;
using Queridometro.API.Application.Commands;
using Queridometro.Core.MediatorHandler;
using Queridometro.WebAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.API.Controllers
{
    public class QueridometroController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public QueridometroController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommand(new RegisterVoteCommand());

            return CustomResponse(result);
        }
    }
}
