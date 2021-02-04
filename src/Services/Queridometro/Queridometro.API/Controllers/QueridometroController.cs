using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queridometro.API.Application.Commands;
using Queridometro.API.Models;
using Queridometro.Core.MediatorHandler;
using Queridometro.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace Queridometro.API.Controllers
{
    [Authorize]
    [Route("api/queridometro")]
    public class QueridometroController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public QueridometroController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote(VoteViewModel vote)
        {
            var result = await _mediatorHandler.SendCommand(new RegisterVoteCommand(vote.ParticipantId, vote.Vote));

            return CustomResponse(result);
        }

        [HttpPost("create-participant")]
        public async Task<IActionResult> CreateParticipant(ParticipantViewModel participant)
        {
            var result = await _mediatorHandler.SendCommand(new CreateParticipantCommand(participant.Name));

            return CustomResponse(result);
        }
    }
}
