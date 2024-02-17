using SoccerSimulator.Models;
using SoccerSimulator.Utils;
using SoccerSimulator.Services.Generators;
using SoccerSimulator.DataProviders;

namespace SoccerSimulator.Services
{
	/// <summary>
	/// Returns a simulation generated based on data of teams
	/// </summary>
	public class SimulationService : ISimulationService
	{
		private static readonly double _goalChanceModifier = 20d;

		private readonly SimulationGenerator _simulationGenerator;

		public SimulationService(ITeamsDataProvider teamsDataProvider, IRandomGenerator randomGenerator)
		{
			_simulationGenerator = new SimulationGenerator(teamsDataProvider, randomGenerator, _goalChanceModifier);
		}

		/// <summary>
		/// Performs a simulation of rounds of matches played between teams
		/// </summary>
		/// <returns>Data that contains match data</returns>
		public async Task<Simulation> GetSimulation() => await _simulationGenerator.GenerateSimulation();
	}
}
