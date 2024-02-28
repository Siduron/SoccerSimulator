using AutoMapper;
using Contracts;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
	[ApiController, Route("api/simulation")]
	public class SimulationController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ISimulationService _simulationService;

		public SimulationController(IMapper mapper, ISimulationService simulationService)
		{
			_mapper = mapper;
			_simulationService = simulationService;
		}

		[HttpGet("getSimulation")]
		public async Task<ActionResult<SimulationDto>> GetSimulation()
		{
			return Ok(_mapper.Map<SimulationDto>(await _simulationService.GetSimulation()));
		}
	}
}
