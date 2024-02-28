using Core.DomainObjects;

namespace Core.Services.Generators.RoundsGenerator
{
	/// <summary>
	/// A test implementation of IRoundsGenerator to provide preset round results to test the ranking in the summary
	/// </summary>
	public sealed class TestRoundsGenerator : IRoundsGenerator
	{
		public async Task<IReadOnlyList<Round>> Generate()
		{
			List<Round> rounds = new List<Round>();

			// Round 1
			rounds.Add(
				new Round(
					new List<Match>()
					{
						new Match(new MatchTeam("Team A", 1), new MatchTeam("Team B", 1)),
						new Match(new MatchTeam("Team C", 2), new MatchTeam("Team D", 1)),
					})
				);

			// Round 2
			rounds.Add(
				new Round(
					new List<Match>()
					{
						new Match(new MatchTeam("Team A", 3), new MatchTeam("Team C", 0)),
						new Match(new MatchTeam("Team B", 4), new MatchTeam("Team D", 2)),
					})
				);

			// Round 3
			rounds.Add(
				new Round(
					new List<Match>()
					{
						new Match(new MatchTeam("Team A", 4), new MatchTeam("Team D", 4)),
						new Match(new MatchTeam("Team B", 2), new MatchTeam("Team C", 2)),
					})
				);

			return await Task.FromResult(rounds);
		}
	}
}
