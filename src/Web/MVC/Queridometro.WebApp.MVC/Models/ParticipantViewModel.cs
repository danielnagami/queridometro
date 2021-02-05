using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Queridometro.Core.Entities;
using System;

namespace Queridometro.WebApp.MVC.Models
{
    public class ParticipantViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string nome { get; set; }
        public string photo { get; set; }
        public Emoji[] emojis { get; set; }
        public string id { get; set; }
        public object notifications { get; set; }
    }

    public class _Id
    {
        public int timestamp { get; set; }
        public int machine { get; set; }
        public int pid { get; set; }
        public int increment { get; set; }
        public DateTime creationTime { get; set; }
    }
}
