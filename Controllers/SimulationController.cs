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
		private readonly ISimulationService _simulationService;

		public SimulationController(IMapper mapper, ISimulationService simulationService)
		{
			_mapper = mapper;
			_simulationService = simulationService;
		}

		public async Task<IActionResult> Index() => View(_mapper.Map<SimulationViewModel>(await _simulationService.GetSimulation()));

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}