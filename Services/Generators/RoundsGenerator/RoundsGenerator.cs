using SoccerSimulator.DataProviders;
using SoccerSimulator.Models;
using SoccerSimulator.Utils;

namespace SoccerSimulator.Services.Generators.RoundsGenerator
{
	/// <summary>
	/// Implementation of the rounds generator for simple team data
	/// </summary>
	public sealed class RoundsGenerator : BaseRoundsGenerator<SimpleTeam>
	{
		private static readonly double GoalChanceModifier = 20d;

		public RoundsGenerator(ITeamsDataProvider<SimpleTeam> teamsDataProvider, IRandomGenerator randomGenerator)
			: base(teamsDataProvider, randomGenerator)
		{
		}

		/// <summary>
		/// Calculate the chance of a goal being scored by a team
		/// </summary>
		/// <param name="strength1"></param>
		/// <param name="strength2"></param>
		/// <returns>Chance of scoring a goal</returns>
		protected override double CalculateGoalChance(SimpleTeam team1, SimpleTeam team2) => (double)team1.Strength / (team1.Strength + team2.Strength) / GoalChanceModifier;
	}
}
