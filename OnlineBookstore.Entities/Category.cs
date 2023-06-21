namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book>? Books { get; set; }
    }
}
