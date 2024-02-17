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
		//public int Played { get; }
		//public int Win { get; }
		//public int Draw { get; }
		//public int Loss { get; }
		//public int For { get; }
		//public int Against { get; }
		//public string Difference { get; }
		public int Points { get; }

		public SummaryTeamViewModel(int position, string team, int points)
		{
			Position = position;
			Team = team;
//			Played = played;
//			Win = win;
//			Draw = draw;
//			Loss = loss;
//			For = @for;
//			Against = against;
//			Difference = difference;
			Points = points;
		}
	}
}
