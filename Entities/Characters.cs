namespace SonicUniverse.Entities
{
    public class Characters : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
