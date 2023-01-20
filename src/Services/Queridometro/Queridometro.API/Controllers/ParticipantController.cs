using MediatR;

using Microsoft.AspNetCore.Mvc;

using Queridometro.API.Application.Commands;
using Queridometro.API.Data;
using Queridometro.API.Models;
using Queridometro.WebAPI.Core.Controllers;

using System.Threading.Tasks;

namespace Queridometro.API.Controllers
{
    //[Authorize]
    [Route("api/Participant")]
    public class ParticipantController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IQueridometroRepository _queridometroRepository;

        public ParticipantController(IMediator mediator, IQueridometroRepository queridometroRepository)
        {
            _mediator = mediator;
            _queridometroRepository = queridometroRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetParticipants()
        {
            return CustomResponse(await _queridometroRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipant(string id)
        {
            return CustomResponse(await _queridometroRepository.Get(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateParticipant(ParticipantViewModel participant)
        {
            var result = await _mediator.Send(new CreateParticipantCommand(participant.Name));

            return CustomResponse(result);
        }
    }
}