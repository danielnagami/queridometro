using MediatR;

using Microsoft.AspNetCore.Mvc;

using Queridometro.API.Application.Commands;
using Queridometro.API.Models;
using Queridometro.WebAPI.Core.Controllers;

using System.Threading.Tasks;

namespace Queridometro.API.Controllers
{
    //[Authorize]
    [Route("api/Queridometro")]
    public class QueridometroController : MainController
    {
        private readonly IMediator _mediator;

        public QueridometroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Vote")]
        public async Task<IActionResult> Vote(VoteViewModel vote)
        {
            var result = await _mediator.Send(new RegisterVoteCommand(vote.ParticipantId, vote.Vote));
            
            return CustomResponse(result);
        }
    }
}