namespace SoccerSimulator.Models
{
	public class Team
	{
		public string Name { get; }
		public int Strength { get; }

		public Team()
		{
			Name = string.Empty;
			Strength = 0;
		}

		public Team(string name, int strength)
		{
			Name = name;
			Strength = strength;
		}
	}
}
