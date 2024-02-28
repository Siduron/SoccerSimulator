using Core.DataProviders;
using Core.DomainObjects;
using Core.DomainObjects.Entities;
using Core.Utils;

namespace Core.Services.Generators.RoundsGenerator
{
	/// <summary>
	/// Simulates rounds of matches between two teams where all teams play against each other once
	/// </summary>
	public abstract class BaseRoundsGenerator<T> : IRoundsGenerator
		where T : BaseTeamEntity
	{
		protected static readonly int RoundLengthMinutes = 90;

		protected readonly IRandomGenerator _randomGenerator;
		private readonly ITeamsDataProvider<T> _teamsDataProvider;

		public BaseRoundsGenerator(ITeamsDataProvider<T> teamsDataProvider, IRandomGenerator randomGenerator)
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
					List<T> shuffledTeams = teams.OrderBy(x => _randomGenerator.NextDouble()).ToList();

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
		private IReadOnlyList<Round> GenerateRounds(List<T> teams)
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
		private Match GenerateMatch(T homeTeam, T awayTeam)
		{
			MatchTeam homeMatchTeam = new(homeTeam.Name, SimulateGoals(homeTeam, awayTeam));
			MatchTeam awayMatchTeam = new(awayTeam.Name, SimulateGoals(awayTeam, homeTeam));

			return new Match(homeMatchTeam, awayMatchTeam);
		}

		/// <summary>
		/// Simulate a match between two teams and calculate the number of goals scored
		/// </summary>
		/// <param name="team1"></param>
		/// <param name="team2"></param>
		/// <returns>Amount of goals scored by team 1</returns>
		private int SimulateGoals(T team1, T team2)
		{
			int goals = 0;

			for(int minute = 1; minute <= RoundLengthMinutes; minute++)
			{
				if(_randomGenerator.NextDouble() < CalculateGoalChance(team1, team2))
				{
					goals++;
				}
			}

			return goals;
		}

		/// <summary>
		/// Calculate the chance of a goal being scored by a team
		/// </summary>
		/// <param name="team1"></param>
		/// <param name="team2"></param>
		/// <returns>Chance of scoring a goal</returns>
		protected abstract double CalculateGoalChance(T team1, T team2);
	}
}
