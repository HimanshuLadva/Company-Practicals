using HimanshuPracticalBE.DBModels;
using System.ComponentModel.DataAnnotations;

namespace HimanshuPracticalBE.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public string? LastModifiedDate { get; set; }
    }
}
