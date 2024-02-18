using Newtonsoft.Json;
using SoccerSimulator.Models;

namespace SoccerSimulator.DataProviders
{
	/// <summary>
	/// Retrieves the data of the teams from a JSON file. 
	/// An implementation of ITeamsDataProvider that uses a database would have been preferred, but JSON is the data source of choice due to the time constraint.
	/// </summary>
	public class JSONTeamsDataProvider : ITeamsDataProvider
	{
		private static readonly string DataPath = "Data/teams.json";

		private readonly ILogger _logger;

		public JSONTeamsDataProvider(ILogger<JSONTeamsDataProvider> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Gets a list of teams
		/// </summary>
		/// <returns>A list of all teams</returns>
		public async Task<IReadOnlyList<Team>?> GetTeams()
		{
			return await Task.Run(IReadOnlyList<Team>? () =>
			{
				try
				{
					return JsonConvert.DeserializeObject<List<Team>>(File.ReadAllText(DataPath));
				}
				catch(Exception ex)
				{
					_logger.LogError(ex.Message);
				}

				return null;
			});
		}
	}
}
