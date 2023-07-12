namespace OnlineBookstoreAPI.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
        
        public string? Email { get; set; }
       
        public string? Address { get; set; }
        
        public string? Country { get; set; }
        
        public string? City { get; set; }
        
        public string? Phone { get; set; }
        
        public string? Description { get; set; }
        
        public string? ProfilePhotoUrl { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime LastActive { get; set; }
        
        public Guid PhotoId { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
