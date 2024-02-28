using Core.DomainObjects;
using Core.Services.Generators.RoundsGenerator;
using Core.Services.Generators.SummaryGenerator;

namespace Core.Services
{
	/// <summary>
	/// Returns a simulation generated based on data of teams
	/// </summary>
	public class SimulationService : ISimulationService
	{
		private readonly IRoundsGenerator _roundsGenerator;

		public SimulationService(IRoundsGenerator roundsGenerator)
		{
			_roundsGenerator = roundsGenerator;
		}

		/// <summary>
		/// Performs a simulation of rounds of matches played between teams
		/// </summary>
		/// <returns>A simulation that contains rounds and their matches and a summary of all matches</returns>
		public async Task<Simulation> GetSimulation()
		{
			IReadOnlyList<Round> rounds = await _roundsGenerator.Generate();
			return new Simulation(rounds, await SummaryGenerator.GenerateTeamSummaries(rounds));
		}
	}
}
