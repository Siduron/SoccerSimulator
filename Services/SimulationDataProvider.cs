using SoccerSimulator.Models;
using SoccerSimulator.Utils;

namespace SoccerSimulator.Services
{
	/// <summary>
	/// Provides data for a simulation
	/// </summary>
	public class SimulationDataProvider : ISimulationDataProvider
	{
		private readonly IRandomGenerator _randomGenerator;
		private readonly SimulationGenerator _simulationGenerator;
		private readonly IReadOnlyList<Team> _teams;

		public SimulationDataProvider()
		{
			_randomGenerator = new RandomGenerator();
			_simulationGenerator = new SimulationGenerator(_randomGenerator);

			_teams = new List<Team>()
			{
				new Team("Team A", 10),
				new Team("Team B", 15),
				new Team("Team C", 30),
				new Team("Team D", 40),
			};
		}

		/// <summary>
		/// Performs a simulation of rounds of matches played between teams
		/// </summary>
		/// <returns>Data that contains match data</returns>
		public Simulation GetSimulationData() => _simulationGenerator.GenerateSimulation(_teams);
	}
}
