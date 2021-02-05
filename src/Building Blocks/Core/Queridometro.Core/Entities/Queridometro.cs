using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Queridometro.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Queridometro.Core.Entities
{
    public class Queridometro : Entity, IAggregateRoot
    {
        public Queridometro(string nome, string photo)
        {
            Nome = nome;
            Photo = photo;
        }

        protected Queridometro() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Nome { get; private set; }

        public string Photo { get; private set; }

        [BsonElement]

        private List<Emoji> _emojis;
        
        public IReadOnlyCollection<Emoji> Emojis => _emojis?.AsReadOnly();


        public void AddEmoji(Emoji emoji)
        {
            _emojis = _emojis ?? new List<Emoji>();
            _emojis.Add(emoji);
        }

        public void RemoveEmoji(Emoji emoji)
        {
            _emojis = _emojis ?? new List<Emoji>();
            _emojis.Remove(emoji);
        }

        public void ClearEmojis()
        {
            _emojis.Clear();
        }
    }
}