using Microsoft.AspNetCore.Mvc;
using SoccerSimulator.ViewModels;
using SoccerSimulator.Services;
using System.Diagnostics;
using SoccerSimulator.Models;

namespace SoccerSimulator.Controllers
{
	public class SimulationController : Controller
	{
		private readonly ILogger<SimulationController> _logger;
		private readonly ISimulationDataProvider _simulationDataProvider;

		public SimulationController(ISimulationDataProvider simulationDataProvider, ILogger<SimulationController> logger)
		{
			_logger = logger;
			_simulationDataProvider = simulationDataProvider;
		}

		public IActionResult Index()
		{
			return View(CreateViewModel(_simulationDataProvider.GetSimulationData()));
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

		private SimulationViewModel CreateViewModel(Simulation simulationModel)
		{
			List<RoundViewModel> rounds = new();

			foreach(var round in simulationModel.Rounds)
			{
				List<MatchViewModel> matches = new();

				foreach(var match in round.Matches)
				{
					matches.Add(new MatchViewModel(new TeamViewModel(match.HomeTeam.Name, match.HomeScore), new TeamViewModel(match.AwayTeam.Name, match.AwayScore)));
				}

				rounds.Add(new RoundViewModel(matches));
			}

			return new(rounds);
		}
	}
}