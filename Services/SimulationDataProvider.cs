using SoccerSimulator.Models;

namespace SoccerSimulator.Services
{
	public class SimulationDataProvider : ISimulationDataProvider
	{
		private readonly IReadOnlyList<Team> _teams;

		public SimulationDataProvider()
		{
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
		public Simulation GetSimulationData() => SimulationGenerator.GenerateSimulation(_teams);
	}
}
