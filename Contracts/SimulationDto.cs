namespace Contracts
{
    public class SimulationDto
    {
        public IReadOnlyList<RoundDto> Rounds { get; }
        public IReadOnlyList<TeamSummaryDto> Summary { get; }

        public SimulationDto(IReadOnlyList<RoundDto> rounds, IReadOnlyList<TeamSummaryDto> summary)
        {
            Rounds = rounds;
            Summary = summary;
        }
    }

    public class RoundDto
    {
        public IReadOnlyList<MatchDto> Matches { get; }

        public RoundDto(IReadOnlyList<MatchDto> matches)
        {
            Matches = matches;
        }
    }

    public class MatchDto
    {
        public MatchTeamDto HomeTeam { get; }
        public MatchTeamDto AwayTeam { get; }

        public MatchDto(MatchTeamDto homeTeam, MatchTeamDto awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
    }

    public class MatchTeamDto
    {
        public string Name { get; }
        public int Score { get; }

        public MatchTeamDto(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public class TeamSummaryDto
    {
        public int Position { get; }
        public string Team { get; }
        public int Win { get; }
        public int Draw { get; }
        public int Loss { get; }
        public int GoalsFor { get; }
        public int GoalsAgainst { get; }
        public int Points { get; }

        public TeamSummaryDto(int position, string team, int win, int draw, int loss, int goalsFor, int goalsAgainst, int points)
        {
            Position = position;
            Team = team;
            Win = win;
            Draw = draw;
            Loss = loss;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            Points = points;
        }
    }
}
