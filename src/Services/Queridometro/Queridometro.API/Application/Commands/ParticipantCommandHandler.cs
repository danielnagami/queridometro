using FluentValidation.Results;
using MediatR;
using Queridometro.API.Data;
using Queridometro.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Queridometro.API.Application.Commands
{
    public class ParticipantCommandHandler : CommandHandler, IRequestHandler<CreateParticipantCommand, ValidationResult>
    {
        private readonly IQueridometroRepository _queridometroRepository;

        public ParticipantCommandHandler(IQueridometroRepository queridometroRepository)
        {
            _queridometroRepository = queridometroRepository;
        }
        public Task<ValidationResult> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            _queridometroRepository.AddParticipant(request.Nome);

            return PersistData(_queridometroRepository.UnitOfWork);
        }
    }
}
