namespace SoccerSimulator.Utils
{
	public class RandomGenerator : IRandomGenerator
	{
		private Random _random;

		public RandomGenerator() 
		{
			_random = new Random();
		}
		public double NextDouble()
		{
			return _random.NextDouble();
		}
	}
}
