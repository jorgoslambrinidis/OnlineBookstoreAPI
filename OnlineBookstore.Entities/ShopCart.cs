namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ShopCart
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public DateTime DateAdded { get; set; }

        [StringLength(250)]
        public string UserId { get; set; } = null!;

        public int BookId { get; set; }
    }
}
