using MongoDB.Bson;
using Queridometro.Core.Entities;
using System;

namespace Queridometro.API.Models
{
    public class VoteViewModel
    {
        public string ParticipantId { get; set; }
        public Emoji Vote { get; set; }
    }
}