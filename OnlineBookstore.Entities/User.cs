namespace OnlineBookstore.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(250)]
        public string Username { get; set; } = null!;

        [StringLength(350)]
        public string Email { get; set; } = null!;

        [StringLength(350)]
        public string? Address { get; set; }

        [StringLength(150)]
        public string? Country { get; set; }

        [StringLength(150)]
        public string? City { get; set; }

        // ..ex: 123gjole123
        public byte[] PasswordHash { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        [StringLength(250)]
        public string? Phone { get; set; } // 070/223-305

        [StringLength(650)]
        public string? Description { get; set; }

        public DateTime UserCreated { get; set; }

        public bool IsAdmin { get; set; }
    }
}
