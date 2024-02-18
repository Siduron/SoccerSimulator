using SoccerSimulator.DataProviders;
using SoccerSimulator.Models;
using SoccerSimulator.Utils;

namespace SoccerSimulator.Services.Generators.RoundsGenerator
{
	/// <summary>
	/// Simulates rounds of matches between two teams where all teams play against each other once
	/// </summary>
	public sealed class RoundsGenerator : IRoundsGenerator
	{
		private static readonly int RoundLengthMinutes = 90;
		private static readonly double GoalChanceModifier = 20d;

		private readonly ITeamsDataProvider _teamsDataProvider;
		private readonly IRandomGenerator _randomGenerator;

		public RoundsGenerator(ITeamsDataProvider teamsDataProvider, IRandomGenerator randomGenerator)
		{
			_teamsDataProvider = teamsDataProvider;
			_randomGenerator = randomGenerator;
		}

		/// <summary>
		/// Generates a simulation model with rounds and matches between teams
		/// </summary>
		/// <returns>The simulation model with all rounds and matches</returns>
		public async Task<IReadOnlyList<Round>> Generate()
		{
			if(await _teamsDataProvider.GetTeams() is { } teams)
			{
				return await Task.Run(() =>
				{
					// Shuffle the teams and generate rounds
					List<Team> shuffledTeams = teams.OrderBy(x => _randomGenerator.NextDouble()).ToList();

					return GenerateRounds(shuffledTeams);
				});
			}

			return new List<Round>();
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
				if(_randomGenerator.NextDouble() < CalculateGoalChance(team1Strength, team2Strength))
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
		private double CalculateGoalChance(int strength1, int strength2) => (double)strength1 / (strength1 + strength2) / GoalChanceModifier;
	}
}
