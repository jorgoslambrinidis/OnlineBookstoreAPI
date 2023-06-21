namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        // important!!!
        public string UserId { get; set; } = null!;

        #region Book details... 

        [StringLength(250)]
        public string BookTitle { get; set; } = null!;

        [StringLength(100)]
        public string? BookAuthor { get; set; }

        [StringLength(100)]
        public string? BookCountry { get; set; }

        [StringLength(70)]
        public string? BookCategory { get; set; }

        [StringLength(50)]
        public string? BookType { get; set; }

        [StringLength(50)]
        public string? BookDimensions { get; set; }

        [StringLength(50)]
        public string? BookWeight { get; set; }

        #endregion

        public int Quantity { get; set; }

        public double Price { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public DateTime RequiredDate { get; set; }
    }
}
