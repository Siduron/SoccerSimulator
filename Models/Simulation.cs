namespace SoccerSimulator.Models
{
	public class Simulation
	{
		public IReadOnlyList<Round> Rounds { get; }
		public IReadOnlyList<TeamSummary> Summary { get; }

		public Simulation(IReadOnlyList<Round> rounds, IReadOnlyList<TeamSummary> summary)
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

	public class TeamSummary
	{
		public int Position { get; }
		public string Team { get; }
		public int Win { get; }
		public int Draw { get; }
		public int Loss { get; }
		public int GoalsFor { get; }
		public int GoalsAgainst { get; }
		public int Points { get; }

		public TeamSummary(int position, string team, int win, int draw, int loss, int goalsFor, int goalsAgainst, int points)
		{
			Position = position;
			Team = team;
			Win = win;
			Draw = draw;
			Loss = loss;
			GoalsFor = goalsFor;
			GoalsAgainst = goalsAgainst;
			Points = points;
		}
	}
}
