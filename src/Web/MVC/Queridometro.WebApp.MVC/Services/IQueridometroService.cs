using Queridometro.Core.Entities;
using Queridometro.WebApp.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Queridometro.WebApp.MVC.Services
{
    public interface IQueridometroService
    {
        Task<ParticipantViewModel> GetParticipant(string id);
        Task<IList<ParticipantViewModel>> GetParticipants();
        Task Vote(string id, Emoji vote);
    }
}