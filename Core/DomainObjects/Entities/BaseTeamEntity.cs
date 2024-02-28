namespace Core.DomainObjects.Entities
{
    /// <summary>
    /// The most basic representation of a team. This can be extended with any sort of additional properties that can be used by the simulation
    /// </summary>
    public class BaseTeamEntity
    {
        public string Name { get; set; }

        public BaseTeamEntity()
        {
            Name = string.Empty;
        }

        public BaseTeamEntity(string name)
        {
            Name = name;
        }
    }
}
