using SoccerSimulator.Models;

namespace SoccerSimulator.DataProviders
{
	public interface ITeamsDataProvider
	{
		Task<IReadOnlyList<Team>?> GetTeams();
	}
}
