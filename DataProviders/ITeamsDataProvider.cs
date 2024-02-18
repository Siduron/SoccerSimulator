using SoccerSimulator.Models;

namespace SoccerSimulator.DataProviders
{
	public interface ITeamsDataProvider
	{
		Task<IEnumerable<Team>?> GetTeams();
	}
}
