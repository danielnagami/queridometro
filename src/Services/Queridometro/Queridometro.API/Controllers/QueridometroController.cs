using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Queridometro.API.Application.Commands;
using Queridometro.API.Data;
using Queridometro.API.Models;
using Queridometro.Core.MediatorHandler;
using Queridometro.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace Queridometro.API.Controllers
{
    //[Authorize]
    [Route("api/queridometro")]
    public class QueridometroController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IQueridometroRepository _queridometroRepository;

        public QueridometroController(IMediator mediator, IQueridometroRepository queridometroRepository)
        {
            _mediator = mediator;
            _queridometroRepository = queridometroRepository;
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote(VoteViewModel vote)
        {
            var result = await _mediator.Send(new RegisterVoteCommand(vote.ParticipantId, vote.Vote));
            
            return CustomResponse(result);
        }

        [HttpGet("get-participant")]
        public async Task<IActionResult> GetParticipant(string id)
        {
            return CustomResponse(_queridometroRepository.Get(ObjectId.Parse(id)).Result);
        }

        [HttpGet("get-participants")]
        public async Task<IActionResult> GetParticipants()
        {
            return CustomResponse(_queridometroRepository.GetAll().Result);
        }

        [HttpPost("create-participant")]
        public async Task<IActionResult> CreateParticipant(ParticipantViewModel participant)
        {
            var result = await _mediator.Send(new CreateParticipantCommand(participant.Name));

            return CustomResponse(result);
        }
    }
}