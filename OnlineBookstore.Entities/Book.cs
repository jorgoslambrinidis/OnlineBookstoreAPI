namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; } = null!;

        #region Author Details

        [StringLength(100)]
        public string? AuthorName { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        #endregion

        #region Publisher Details

        [StringLength(250)]
        public string? PublisherName { get; set; }

        public int PublisherId { get; set; }

        public Publisher? Publisher { get; set; }

        #endregion

        #region Category Details 

        [StringLength(60)]
        public string? CategoryName { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        #endregion

        public DateTime YearOfIssue { get; set; }

        public int NumberOfPages { get; set; }

        [StringLength(80)]
        public string? Genre { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        [StringLength(50)]
        public string? Language { get; set; }

        public string? Country { get; set; }

        public int Edition { get; set; }

        [StringLength(50)]
        public string? Dimension { get; set; } // "20x15x5"

        public double Weight { get; set; }

        [StringLength(50)]
        public string? Shipping { get; set; }

        [StringLength(350)]
        public string? PhotoUrl { get; set; }

        public int Copies { get; set; }

        public int SoldItems { get; set; }

        public virtual ICollection<Photo>? Photos { get; set; }
    }
}
