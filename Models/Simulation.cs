namespace SoccerSimulator.Models
{
	public class Simulation
	{
		public IReadOnlyList<Round> Rounds { get; }

		public Simulation(IReadOnlyList<Round> rounds)
		{
			Rounds = rounds;
		}
	}

	public class Round
	{
		public IReadOnlyList<Match> Matches { get; }

		public Round(IReadOnlyList<Match> matches)
		{
			Matches = matches;
		}
	}

	public class Match
	{
		public Team HomeTeam { get; }
		public Team AwayTeam { get; }
		public int HomeScore { get; set; }
		public int AwayScore { get; set; }

		public Match(Team homeTeam, Team awayTeam, int homeScore, int awayScore)
		{
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
			HomeScore = homeScore;
			AwayScore = awayScore;
		}
	}
}
