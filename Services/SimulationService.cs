using SoccerSimulator.Models;
using SoccerSimulator.Utils;
using SoccerSimulator.Services.Generators;
using SoccerSimulator.DataProviders;
using SoccerSimulator.Services.Generators.RoundsGenerator;

namespace SoccerSimulator.Services
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
			//_roundsGenerator = new RoundsGenerator(teamsDataProvider, randomGenerator, _goalChanceModifier);
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
