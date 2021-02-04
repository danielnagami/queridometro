using MongoDB.Bson;
using Queridometro.Core.Entities;
using Queridometro.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.API.Application.Commands
{
    public class RegisterVoteCommand : Command
    {
        public ObjectId ParticipantId { get; set; }
        public Emoji Vote { get; set; }

        public RegisterVoteCommand(string participantId, Emoji vote)
        {
            ParticipantId = ObjectId.Parse(participantId);
            Vote = vote;
        }
    }
}
