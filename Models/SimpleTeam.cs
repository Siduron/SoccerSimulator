namespace SoccerSimulator.Models
{
	public class SimpleTeam : BaseTeam
	{
		public int Strength { get; set; }

		public SimpleTeam()
		{
			Strength = 0;
		}

		public SimpleTeam(string name, int strength)
			: base(name)
		{
			Strength = strength;
		}
	}
}
