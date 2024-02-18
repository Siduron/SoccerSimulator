using SoccerSimulator.Models;

namespace SoccerSimulator.Services.Generators.RoundsGenerator
{
	public interface IRoundsGenerator
	{
		public Task<IReadOnlyList<Round>> Generate();
	}
}
