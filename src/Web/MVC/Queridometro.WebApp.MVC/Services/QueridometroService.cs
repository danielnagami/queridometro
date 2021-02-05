using Microsoft.Extensions.Configuration;
using Queridometro.Core.Entities;
using Queridometro.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Queridometro.WebApp.MVC.Services
{
    public class QueridometroService : IQueridometroService
    {
        private readonly HttpClient _httpClient;

        public QueridometroService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetSection("QueridometroAPI").Value);

            _httpClient = httpClient;
        }
        public async Task<ParticipantViewModel> GetParticipant(string id)
        {
            var response = await _httpClient.GetAsync($"/api/queridometro/get-participant?id={id}");

            return JsonSerializer.Deserialize<ParticipantViewModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IList<ParticipantViewModel>> GetParticipants()
        {
            var response = await _httpClient.GetAsync($"/api/queridometro/get-participants");

            return JsonSerializer.Deserialize<IList<ParticipantViewModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task Vote(string id, Emoji vote)
        {
            var dic = new Dictionary<string, object>()
            {
                { "participantId", id },
                { "vote", (int)vote }
            };

            var body = new StringContent(JsonSerializer.Serialize(dic), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"/api/queridometro/vote", body);
        }
    }
}
