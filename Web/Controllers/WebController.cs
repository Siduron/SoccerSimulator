using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Web.ViewModels;
using Web.Services;

namespace Web.Controllers
{
	public class WebController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IWebService _webService;

		public WebController(IMapper mapper, IWebService simulationService)
		{
			_mapper = mapper;
			_webService = simulationService;
		}

		public async Task<IActionResult> Index() => View(_mapper.Map<SimulationViewModel>(await _webService.GetSimulation()));

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}