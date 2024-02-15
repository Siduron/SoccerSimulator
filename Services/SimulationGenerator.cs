using SoccerSimulator.Models;

namespace SoccerSimulator.Services
{
	/// <summary>
	/// Simulates rounds of matches between two teams where all teams play against each other once
	/// </summary>
	public static class SimulationGenerator
	{
		private static int RoundLengthMinutes = 90;
		private static Random Rand = new();

		/// <summary>
		/// Generates a simulation model with rounds and matches between teams
		/// </summary>
		/// <param name="teams">The teams to use for the matches</param>
		/// <returns>The simulation model with all rounds and matches</returns>
		public static Simulation GenerateSimulation(IReadOnlyList<Team> teams) => new(GenerateRounds(teams.OrderBy(x => Rand.Next()).ToList()));

		/// <summary>
		/// Generates a list of rounds with matches between teams
		/// </summary>
		/// <param name="teams"></param>
		/// <returns>List of rounds</returns>
		private static IReadOnlyList<Round> GenerateRounds(List<Team> teams)
		{
			List<Round> rounds = new();

			int totalTeams = teams.Count;

			for(int round = 0; round < totalTeams - 1; round++)
			{
				List<Match> matches = new();

				for(int i = 0; i < totalTeams / 2; i++)
				{
					matches.Add(GenerateMatch(teams[i], teams[totalTeams - 1 - i]));
				}

				rounds.Add(new Round(matches));

				// Rotate teams for the next round
				teams.Insert(1, teams[totalTeams - 1]);
				teams.RemoveAt(totalTeams);
			}

			return rounds;
		}

		/// <summary>
		/// Generates a match between two teams
		/// </summary>
		/// <param name="homeTeam">The home team</param>
		/// <param name="awayTeam">The away team</param>
		/// <returns>A model of a match with two teams and their scores</returns>
		private static Match GenerateMatch(Team homeTeam, Team awayTeam)
		{
			return new Match(homeTeam, awayTeam, SimulateGoals(homeTeam.Strength, awayTeam.Strength), SimulateGoals(awayTeam.Strength, homeTeam.Strength));
		}

		/// <summary>
		/// Simulate a match between two teams and calculate the number of goals scored
		/// </summary>
		/// <param name="team1Strength"></param>
		/// <param name="team2Strength"></param>
		/// <returns>Amount of goals scored by team 1</returns>
		private static int SimulateGoals(int team1Strength, int team2Strength)
		{
			double team1Chance = CalculateGoalChance(team1Strength, team2Strength) / 10d;

			int goals = 0;

			for(int minute = 1; minute <= RoundLengthMinutes; minute++)
			{
				if(Rand.NextDouble() < team1Chance)
				{
					goals++;
				}
			}

			return goals;
		}

		/// <summary>
		/// Calculate the chance of a goal being scored by a team
		/// </summary>
		/// <param name="strength1"></param>
		/// <param name="strength2"></param>
		/// <returns>Chance of scoring a goal</returns>
		private static double CalculateGoalChance(int strength1, int strength2)
		{
			double totalStrength = strength1 + strength2;
			double team1Chance = strength1 / totalStrength;

			return team1Chance;
		}
	}
}
