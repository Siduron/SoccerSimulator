using Microsoft.AspNetCore.Mvc;
using SoccerSimulator.ViewModels;
using SoccerSimulator.Services;
using System.Diagnostics;
using AutoMapper;

namespace SoccerSimulator.Controllers
{
	public class SimulationController : Controller
	{
		// TODO: remove this?
		private readonly ILogger<SimulationController> _logger;
		private readonly IMapper _mapper;
		private readonly ISimulationDataProvider _simulationDataProvider;

		public SimulationController(ISimulationDataProvider simulationDataProvider, ILogger<SimulationController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
			_simulationDataProvider = simulationDataProvider;
		}

		public IActionResult Index() => View(_mapper.Map<SimulationViewModel>(_simulationDataProvider.GetSimulationData()));
		
		// TODO: remove this?
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