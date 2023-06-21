namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; } = null!;

        [StringLength(650)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
