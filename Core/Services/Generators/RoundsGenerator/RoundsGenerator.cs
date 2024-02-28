using Core.DataProviders;
using Core.DomainObjects.Entities;
using Core.Utils;

namespace Core.Services.Generators.RoundsGenerator
{
	/// <summary>
	/// Implementation of the rounds generator for simple team data
	/// </summary>
	public sealed class RoundsGenerator : BaseRoundsGenerator<SimpleTeamEntity>
	{
		private static readonly double GoalChanceModifier = 20d;

		public RoundsGenerator(ITeamsDataProvider<SimpleTeamEntity> teamsDataProvider, IRandomGenerator randomGenerator)
			: base(teamsDataProvider, randomGenerator)
		{
		}

		/// <summary>
		/// Calculate the chance of a goal being scored by a team
		/// </summary>
		/// <param name="team1"></param>
		/// <param name="team2"></param>
		/// <returns>Chance of scoring a goal</returns>
		protected override double CalculateGoalChance(SimpleTeamEntity team1, SimpleTeamEntity team2) => (double)team1.Strength / (team1.Strength + team2.Strength) / GoalChanceModifier;
	}
}
