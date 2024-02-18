using Microsoft.Data.Sqlite;
using SoccerSimulator.Models;
using Dapper;

namespace SoccerSimulator.DataProviders
{
	/// <summary>
	/// Implementation of <see cref="ITeamsDataProvider"/> that retrieves teams from a SQL database and maps it to a model using Dapper.
	/// </summary>
	public sealed class SQLTeamsDataProvider : ITeamsDataProvider<SimpleTeam>
	{
		private static readonly string ConnectionString = "Data Source=:memory:";
		private static readonly string DataInitStringPath = "Data/teams.sql";
		private static readonly string TeamsQuery = "SELECT Name, Strength FROM Teams";

		private readonly ILogger _logger;

		public SQLTeamsDataProvider(ILogger<SQLTeamsDataProvider> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Gets a list of teams
		/// </summary>
		/// <returns>A list of all teams</returns>
		public async Task<IEnumerable<SimpleTeam>?> GetTeams()
		{
			try
			{
				using(SqliteConnection connection = new(ConnectionString))
				{
					await connection.OpenAsync();
					await InitDatabase(connection);

					return await connection.QueryAsync<SimpleTeam>(TeamsQuery);
				}
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return await Task.FromResult(new List<SimpleTeam>());
		}

		/// <summary>
		/// Initialize the in memory database with the query in teams.sql
		/// </summary>
		/// <param name="connection"></param>
		private async Task InitDatabase(SqliteConnection connection)
		{
			string initQuery = await File.ReadAllTextAsync(DataInitStringPath);

			SqliteCommand command = connection.CreateCommand();
			command.CommandText = initQuery;

			await command.ExecuteNonQueryAsync();
		}
	}
}
