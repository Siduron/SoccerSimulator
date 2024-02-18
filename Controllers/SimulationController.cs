using Microsoft.AspNetCore.Mvc;
using SoccerSimulator.ViewModels;
using SoccerSimulator.Services;
using System.Diagnostics;
using AutoMapper;

namespace SoccerSimulator.Controllers
{
	public class SimulationController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ISimulationService _simulationDataProvider;

		public SimulationController(IMapper mapper, ISimulationService simulationDataProvider)
		{
			_mapper = mapper;
			_simulationDataProvider = simulationDataProvider;
		}

		public async Task<IActionResult> Index() => View(_mapper.Map<SimulationViewModel>(await _simulationDataProvider.GetSimulation()));

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}