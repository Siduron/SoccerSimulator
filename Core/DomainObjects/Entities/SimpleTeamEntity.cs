namespace Core.DomainObjects.Entities
{
    public class SimpleTeamEntity : BaseTeamEntity
    {
        public int Strength { get; set; }

        public SimpleTeamEntity()
        {
            Strength = 0;
        }

        public SimpleTeamEntity(string name, int strength)
            : base(name)
        {
            Strength = strength;
        }
    }
}
