namespace OnlineBookstore.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        // TODO: Relation with other table/s
    }
}
