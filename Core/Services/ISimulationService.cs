using Core.DomainObjects;

namespace Core.Services
{
	public interface ISimulationService
	{
		Task<Simulation> GetSimulation();
	}
}
