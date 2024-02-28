using Core.DomainObjects.Entities;

namespace Core.DataProviders
{
	public interface ITeamsDataProvider<T>
		where T : BaseTeamEntity
	{
		Task<IEnumerable<T>?> GetTeams();
	}
}
