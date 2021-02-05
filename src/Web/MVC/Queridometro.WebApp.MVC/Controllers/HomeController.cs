using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Queridometro.WebAPI.Core.Controllers;
using Queridometro.WebApp.MVC.Models;
using Queridometro.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQueridometroService _queridometroService;

        public HomeController(IQueridometroService queridometroService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _queridometroService = queridometroService;
        }

        public async Task<IActionResult> Index()
        {
            var participants = await _queridometroService.GetParticipants();

            return View(participants);
        }

        [HttpGet("Participant")]
        public async Task<IActionResult> Participant(string id)
        {
            var participant = await _queridometroService.GetParticipant(id);

            return View(participant);
        }

        [HttpPost("Vote")]
        public async Task<IActionResult> Vote(VoteViewModel vote)
        {
            await _queridometroService.Vote(vote.Id, vote.Emoji);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
