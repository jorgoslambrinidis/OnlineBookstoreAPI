namespace OnlineBookstore.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public bool IsPopular { get; set; }

        // TODO: Relation with other table/s
    }
}
