namespace SoccerSimulator.Models
{
	/// <summary>
	/// The most basic representation of a team. This can be extended with any sort of additional properties that can be used by the simulation
	/// </summary>
	public class BaseTeam
	{
		public string Name { get; set; }

		public BaseTeam()
		{
			Name = string.Empty;
		}

		public BaseTeam(string name)
		{
			Name = name;
		}
	}
}
