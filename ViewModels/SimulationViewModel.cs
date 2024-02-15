using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SoccerSimulator.ViewModels
{
	public class SimulationViewModel : PageModel
	{
		public IReadOnlyList<RoundViewModel> Rounds { get; }

		public SimulationViewModel(IReadOnlyList<RoundViewModel> rounds)
		{
			Rounds = rounds;
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
		public TeamViewModel HomeTeam { get; }
		public TeamViewModel AwayTeam { get; }

		public MatchViewModel(TeamViewModel homeTeam, TeamViewModel awayTeam)
		{
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
		}
	}

	public class TeamViewModel
	{
		public string Name { get; }
		public int Score { get; }

		public TeamViewModel(string name, int score)
		{
			Name = name;
			Score = score;
		}
	}
}
