using Core.DataProviders;
using Core.DomainObjects;
using Core.DomainObjects.Entities;
using Core.Services.Generators.RoundsGenerator;
using Core.Utils;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace RoundGeneratorTests
{
	public class RoundsGeneratorTests
	{
		private readonly RoundsGenerator _generator = null!;
		private readonly ITeamsDataProvider<SimpleTeamEntity> _dataProvider;
		private readonly IRandomGenerator _randomGenerator;
		private readonly IEnumerable<SimpleTeamEntity> _mockTeamsData = new List<SimpleTeamEntity>()
		{
			new SimpleTeamEntity("Test Team A", 5),
			new SimpleTeamEntity("Test Team B", 10),
			new SimpleTeamEntity("Test Team C", 15),
			new SimpleTeamEntity("Test Team D", 20)
		};
		

		public RoundsGeneratorTests()
		{
			_dataProvider = A.Fake<ITeamsDataProvider<SimpleTeamEntity>>();
			A.CallTo(() => _dataProvider.GetTeams()).Returns(_mockTeamsData);

			_randomGenerator = A.Fake<IRandomGenerator>();
			_generator = new RoundsGenerator(_dataProvider, _randomGenerator);
		}

		[Fact]
		public async Task RoundsGenerator_Generate_ReturnsThreeRounds()
		{
			IReadOnlyList<Round> rounds = await _generator.Generate();

			rounds.Count.Should().Be(3);
		}
	}
}
