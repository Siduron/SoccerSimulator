using Contracts;

namespace Web.Services
{
	public sealed class WebService : IWebService
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public WebService(IHttpClientFactory httpClientFactory, ILogger logger)
		{
			_httpClient = httpClientFactory.CreateClient("CoreHttpClient");
			_logger = logger;
		}

		public async Task<SimulationDto?> GetSimulation()
		{
			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync("api/simulation/getSimulation");

				if(response.IsSuccessStatusCode)
				{
					SimulationDto? simulation = await response.Content.ReadFromJsonAsync<SimulationDto>();

					if(simulation != null)
					{
						return simulation;
					}

				}
			}
			catch(Exception e)
			{
				_logger.LogError(e.Message);
			}

			return new SimulationDto(new List<RoundDto>(), new List<TeamSummaryDto>());
		}
	}
}
