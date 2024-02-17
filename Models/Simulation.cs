namespace SoccerSimulator.Models
{
	public class Simulation
	{
		public IReadOnlyList<Round> Rounds { get; }
		public IReadOnlyList<SummaryTeam> Summary { get; }

		public Simulation(IReadOnlyList<Round> rounds, IReadOnlyList<SummaryTeam> summary)
		{
			Rounds = rounds;
			Summary = summary;
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
		public MatchTeam HomeTeam { get; }
		public MatchTeam AwayTeam { get; }

		public Match(MatchTeam homeTeam, MatchTeam awayTeam)
		{
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
		}
	}

	public class MatchTeam
	{
		public string Name { get; }
		public int Score { get; }

		public MatchTeam(string name, int score)
		{
			Name = name;
			Score = score;
		}
	}

	public class SummaryTeam
	{
		public int Position { get; }
		public string Team { get; }
		public int Points { get; }

		public SummaryTeam(int position, string team, int points)
		{
			Position = position;
			Team = team;
			Points = points;
		}
	}
}
