using FluentValidation.Results;
using MediatR;
using Queridometro.Core.DomainObjects;
using Queridometro.Core.Messages;
using System.Threading.Tasks;

namespace Queridometro.Core.MediatorHandler
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}