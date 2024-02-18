﻿using Newtonsoft.Json;
using SoccerSimulator.Models;

namespace SoccerSimulator.DataProviders
{
	/// <summary>
	/// Implementation of <see cref="ITeamsDataProvider"/> that retrieves the data of the teams from a JSON file. 
	/// This was a solution to provide data before SQLTeamsDataProvider was implemented, so it's kind of legacy now.
	/// </summary>
	public sealed class JSONTeamsDataProvider : ITeamsDataProvider<SimpleTeam>
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
		public async Task<IEnumerable<SimpleTeam>?> GetTeams()
		{
			return await Task.Run(IEnumerable<SimpleTeam>? () =>
			{
				try
				{
					return JsonConvert.DeserializeObject<List<SimpleTeam>>(File.ReadAllText(DataPath));
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
