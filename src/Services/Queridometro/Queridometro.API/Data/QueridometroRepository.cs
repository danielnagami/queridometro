using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Queridometro.API.Models;
using Queridometro.Core.Data;
using Queridometro.Core.Entities;
using Queridometro.WebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.API.Data
{
    public class QueridometroRepository : IQueridometroRepository, IUnitOfWork
    {
        private IMongoCollection<Core.Entities.Queridometro> _queridometro;
        private MongoSettings _appSettings;

        public IUnitOfWork UnitOfWork => this;

        public QueridometroRepository(IOptions<MongoSettings> options)
        {
            _appSettings = options.Value;

            var client = new MongoClient(_appSettings.ConnectionString);
            var database = client.GetDatabase(_appSettings.Database);

            _queridometro = database.GetCollection<Core.Entities.Queridometro>(_appSettings.Collection);
        }

        public void AddVote(ObjectId Id, Emoji vote)
        {
            //_queridometro.UpdateOne(x => x.Id.Equals(Id), );
            var participant = _queridometro.Find(x => x._id == Id).FirstOrDefault();
            participant.AddEmoji(vote);
            _queridometro.ReplaceOne(book => book._id == Id, participant);
        }

        public async Task<Core.Entities.Queridometro> Get(ObjectId id)
        {
            return await _queridometro.Find(x => x._id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Core.Entities.Queridometro>> GetAll()
        {
            return await _queridometro.Find(x => x != null).ToListAsync();
        }

        public void AddParticipant(string name)
        {
            var participant = new Core.Entities.Queridometro(name, "");
            _queridometro.InsertOne(participant);
        }

        public async Task<bool> Commit()
        {
            return true;
        }
    }
}
