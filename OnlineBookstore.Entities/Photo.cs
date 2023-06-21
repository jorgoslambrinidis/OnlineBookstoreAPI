namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(450)]
        public string Url { get; set; } = null!;

        [StringLength(650)]
        public string? Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }
    }
}
