using MongoDB.Bson;
using Queridometro.Core.Data;
using Queridometro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Queridometro.API.Data
{
    public interface IQueridometroRepository : IRepository<Core.Entities.Queridometro>
    {
        void AddVote(ObjectId Id, Emoji vote);
        void AddParticipant(string name);
        Task<IList<Core.Entities.Queridometro>> GetAll();
        Task<Core.Entities.Queridometro> Get(string id);
    }
}
