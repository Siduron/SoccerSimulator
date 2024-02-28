namespace Core.Utils
{
	/// <summary>
	/// Implementation of IRandomGenerator that uses System.Random
	/// </summary>
	public class RandomGenerator : IRandomGenerator
	{
		private Random _random;

		public RandomGenerator()
		{
			_random = new Random();
		}

		public double NextDouble() => _random.NextDouble();
	}
}
