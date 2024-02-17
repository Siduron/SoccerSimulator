using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SoccerSimulator.ViewModels
{
	public class SimulationViewModel : PageModel
	{
		public IReadOnlyList<RoundViewModel> Rounds { get; }

		public IReadOnlyList<SummaryTeamViewModel> Summary { get; }

		public SimulationViewModel(IReadOnlyList<RoundViewModel> rounds, IReadOnlyList<SummaryTeamViewModel> summary)
		{
			Rounds = rounds;
			Summary = summary;
		}
	}

	public class RoundViewModel
	{
		public IReadOnlyList<MatchViewModel> Matches { get; }

		public RoundViewModel(IReadOnlyList<MatchViewModel> matches)
		{
			Matches = matches;
		}
	}

	public class MatchViewModel
	{
		public MatchTeamViewModel HomeTeam { get; }
		public MatchTeamViewModel AwayTeam { get; }

		public MatchViewModel(MatchTeamViewModel homeTeam, MatchTeamViewModel awayTeam)
		{
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
		}
	}

	public class MatchTeamViewModel
	{
		public string Name { get; }
		public int Score { get; }

		public MatchTeamViewModel(string name, int score)
		{
			Name = name;
			Score = score;
		}
	}

	public class SummaryTeamViewModel
	{
		public int Position { get; }
		public string Team { get; }
		public int Played => Win + Draw + Loss;
		public int Win { get; }
		public int Draw { get; }
		public int Loss { get; }
		public int GoalsFor { get; }
		public int GoalsAgainst { get; }
		public int Points { get; }
		public int GoalDifference => GoalsFor - GoalsAgainst;

		public SummaryTeamViewModel(int position, string team, int win, int draw, int loss, int goalsFor, int goalsAgainst, int points)
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
