namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(400)]
        public string? ShortDescription { get; set; }

        public bool IsPopular { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
