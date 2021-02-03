using FluentValidation.Results;
using MediatR;
using Queridometro.Core.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Queridometro.API.Application.Commands
{
    public class QueridometroCommandHandler : CommandHandler, IRequestHandler<RegisterVoteCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(RegisterVoteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
