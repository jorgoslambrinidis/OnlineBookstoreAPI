namespace OnlineBookstore.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Country { get; set; }

        // TODO: Relation with other table/s
    }
}
