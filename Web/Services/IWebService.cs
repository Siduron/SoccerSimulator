using Contracts;

namespace Web.Services
{
	public interface IWebService
	{
		Task<SimulationDto?> GetSimulation();
	}
}
