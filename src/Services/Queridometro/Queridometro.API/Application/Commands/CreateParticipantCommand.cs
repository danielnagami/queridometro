using Queridometro.Core.Messages;
using System;

namespace Queridometro.API.Application.Commands
{
    public class CreateParticipantCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public CreateParticipantCommand(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}