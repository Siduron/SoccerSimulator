using SoccerSimulator.Models;

namespace SoccerSimulator.Services
{
	public interface ISimulationService
	{
		Task<Simulation> GetSimulation();
	}
}
