using Core.DomainObjects;
using Core.DomainObjects.Entities;
using Core.Services.Generators.RoundsGenerator;
using Core.Services.Generators.SummaryGenerator;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace RoundGeneratorTests
{
	public class SummaryGeneratorTests
	{
		private readonly IRoundsGenerator _roundsGenerator;
		private readonly IReadOnlyList<Round> _rounds = new List<Round>()
		{
			new Round(new List<Match>() 
			{
				new Match(new MatchTeam("Test Team A", 2), new MatchTeam("Test Team B", 1)),
				new Match(new MatchTeam("Test Team C", 2), new MatchTeam("Test Team D", 1))
			})
		};

		public SummaryGeneratorTests()
		{
			_roundsGenerator = A.Fake<IRoundsGenerator>();
		}

		[Fact]
		public async Task SummaryGenerator_NumTeams()
		{
			IReadOnlyList<TeamSummary> summary = await SummaryGenerator.GenerateTeamSummaries(await _roundsGenerator.Generate());
			A.CallTo(() => _roundsGenerator.Generate()).Returns(Task.FromResult(_rounds));

			summary.Count.Should().Be(4);
		}
	}
}
