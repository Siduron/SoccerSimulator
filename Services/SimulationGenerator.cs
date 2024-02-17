using SoccerSimulator.Models;
using SoccerSimulator.Utils;

namespace SoccerSimulator.Services
{
	/// <summary>
	/// Simulates rounds of matches between two teams where all teams play against each other once
	/// </summary>
	public sealed class SimulationGenerator
	{
		private static readonly int RoundLengthMinutes = 90;
		private IRandomGenerator RandomGenerator;

		public SimulationGenerator(IRandomGenerator randomGenerator)
		{
			RandomGenerator = randomGenerator;
		}

		/// <summary>
		/// Generates a simulation model with rounds and matches between teams
		/// </summary>
		/// <param name="teams">The teams to use for the matches</param>
		/// <returns>The simulation model with all rounds and matches</returns>
		public Simulation GenerateSimulation(IReadOnlyList<Team> teams)
		{
			IReadOnlyList<Round> rounds = GenerateRounds(teams.OrderBy(x => RandomGenerator.NextDouble()).ToList());
			IReadOnlyList<SummaryTeam> summary = GenerateSummaryTeams(rounds.SelectMany(round => round.Matches).ToList());	

			return new Simulation(rounds, summary);
		}

		/// <summary>
		/// Generates a list of rounds with matches between teams
		/// </summary>
		/// <param name="teams"></param>
		/// <returns>List of rounds</returns>
		private IReadOnlyList<Round> GenerateRounds(List<Team> teams)
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
		private Match GenerateMatch(Team homeTeam, Team awayTeam)
		{
			MatchTeam homeMatchTeam = new(homeTeam.Name, SimulateGoals(homeTeam.Strength, awayTeam.Strength));
			MatchTeam awayMatchTeam = new(awayTeam.Name, SimulateGoals(awayTeam.Strength, homeTeam.Strength));

			return new Match(homeMatchTeam, awayMatchTeam);
		}

		/// <summary>
		/// Simulate a match between two teams and calculate the number of goals scored
		/// </summary>
		/// <param name="team1Strength"></param>
		/// <param name="team2Strength"></param>
		/// <returns>Amount of goals scored by team 1</returns>
		private int SimulateGoals(int team1Strength, int team2Strength)
		{
			int goals = 0;

			for(int minute = 1; minute <= RoundLengthMinutes; minute++)
			{
				if(RandomGenerator.NextDouble() < CalculateGoalChance(team1Strength, team2Strength) / 10d) // TODO: fix magic number
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

		private static IReadOnlyList<SummaryTeam> GenerateSummaryTeams(IReadOnlyList<Match> matches)
		{
			Dictionary<string, int> teamScores = new Dictionary<string, int>();

			foreach(Match match in matches)
			{
				UpdateTeamScore(match.HomeTeam);
				UpdateTeamScore(match.AwayTeam);
			}

			List<(string, int)> orderedTeamScores = teamScores.OrderByDescending(team => team.Value).Select(x => (x.Key, x.Value)).ToList();
			List<SummaryTeam> summaryTeams = new List<SummaryTeam>();

			for(int i = 0, count = orderedTeamScores.Count; i < count; i++)
			{
				summaryTeams.Add(new SummaryTeam(i + 1, orderedTeamScores[i].Item1, orderedTeamScores[i].Item2));
			}

			void UpdateTeamScore(MatchTeam matchTeam)
			{
				if(teamScores.TryGetValue(matchTeam.Name, out int teamScore))
				{
					teamScores[matchTeam.Name] += matchTeam.Score;
				}
				else
				{
					teamScores.Add(matchTeam.Name, matchTeam.Score);
				}
			}

			return summaryTeams;
		}
	}
}
