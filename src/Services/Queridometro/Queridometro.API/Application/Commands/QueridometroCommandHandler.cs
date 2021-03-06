﻿using FluentValidation.Results;
using MediatR;
using Queridometro.API.Data;
using Queridometro.Core.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Queridometro.API.Application.Commands
{
    public class QueridometroCommandHandler : CommandHandler, IRequestHandler<RegisterVoteCommand, ValidationResult>
    {
        private readonly IQueridometroRepository _queridometroRepository;

        public QueridometroCommandHandler(IQueridometroRepository queridometroRepository)
        {
            _queridometroRepository = queridometroRepository;
        }

        public Task<ValidationResult> Handle(RegisterVoteCommand request, CancellationToken cancellationToken)
        {
            _queridometroRepository.AddVote(request.ParticipantId, request.Vote);

            return PersistData(_queridometroRepository.UnitOfWork);
        }
    }
}