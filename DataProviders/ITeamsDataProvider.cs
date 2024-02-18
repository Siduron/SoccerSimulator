using SoccerSimulator.Models;

namespace SoccerSimulator.DataProviders
{
	public interface ITeamsDataProvider<T>
		where T : BaseTeam
	{
		Task<IEnumerable<T>?> GetTeams();
	}
}
