using SoccerSimulator.Models;

namespace SoccerSimulator.Services.Generators.SummaryGenerator
{
	/// <summary>
	/// Creates a summary of the provided matches
	/// </summary>
	public static class SummaryGenerator
	{
		private static readonly int PointsAmountWin = 3;
		private static readonly int PointsAmountDraw = 1;

		/// <summary>
		/// Generates the summary of each team
		/// </summary>
		/// <param name="rounds"></param>
		/// <returns>A list with data that summarizes the results of a team, sorted by rank (which is based on various results)</returns>
		public static async Task<IReadOnlyList<TeamSummary>> GenerateTeamSummaries(IReadOnlyList<Round> rounds)
		{
			return await Task.Run(() =>
			{
				IReadOnlyList<Match> matches = rounds.SelectMany(round => round.Matches).ToList();

				Dictionary<string, SummaryData> teamData = new Dictionary<string, SummaryData>();

				foreach(Match match in matches)
				{
					UpdateTeamData(ref teamData, match.HomeTeam, match.AwayTeam);
					UpdateTeamData(ref teamData, match.AwayTeam, match.HomeTeam);
				}

				// Order the teams by points, then by goal difference, then by goals scored to determine the rank
				IReadOnlyList<(string TeamName, SummaryData Data)> orderedTeamScores = teamData
					.OrderByDescending(team => team.Value.Points) // Order by points
					.ThenByDescending(team => team.Value.GoalsFor - team.Value.GoalsAgainst) // Then by goal difference
					.ThenByDescending(team => team.Value.GoalsFor) // Then by goals scored
					// Sorting by goals against wouldn't make sense, as it's already taken into account in the goal difference
					// I'd order by a head 2 head result, but what does that mean and is it even possible if each team plays against eachother just once?
					.Select(x => (x.Key, x.Value)).ToList();

				List<TeamSummary> summaryTeams = new List<TeamSummary>();

				for(int i = 0, count = orderedTeamScores.Count; i < count; i++)
				{
					SummaryData teamSummaryData = orderedTeamScores[i].Data;
					summaryTeams.Add(new TeamSummary(i + 1, orderedTeamScores[i].TeamName, teamSummaryData.Won, teamSummaryData.Draw, teamSummaryData.Loss, teamSummaryData.GoalsFor, teamSummaryData.GoalsAgainst, teamSummaryData.Points));
				}

				return summaryTeams;
			});
		}

		/// <summary>
		/// Updates the data of a team within the referenced dictionary
		/// </summary>
		/// <param name="teamData">Data of all teams</param>
		/// <param name="team">The data of the team to update</param>
		/// <param name="opponent">The data of the opponent</param>
		private static void UpdateTeamData(ref Dictionary<string, SummaryData> teamData, MatchTeam team, MatchTeam opponent)
		{
			SummaryData teamSummaryData;

			teamData.TryGetValue(team.Name, out teamSummaryData);

			if(team.Score > opponent.Score)
			{
				teamSummaryData.Won++;
				teamSummaryData.Points += PointsAmountWin;
			}
			else if(team.Score < opponent.Score)
			{
				teamSummaryData.Loss++;
			}
			else
			{
				teamSummaryData.Draw++;
				teamSummaryData.Points += PointsAmountDraw;
			}

			teamSummaryData.GoalsFor += team.Score;
			teamSummaryData.GoalsAgainst += opponent.Score;

			teamData[team.Name] = teamSummaryData;
		}

		/// <summary>
		/// Used to cache data based on matches
		/// </summary>
		private struct SummaryData
		{
			public int Won;
			public int Loss;
			public int Draw;
			public int GoalsFor;
			public int GoalsAgainst;
			public int Points;
		}
	}
}
