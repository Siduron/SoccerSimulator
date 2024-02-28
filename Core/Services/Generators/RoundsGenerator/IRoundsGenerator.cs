using Core.DomainObjects;

namespace Core.Services.Generators.RoundsGenerator
{
	public interface IRoundsGenerator
	{
		public Task<IReadOnlyList<Round>> Generate();
	}
}
