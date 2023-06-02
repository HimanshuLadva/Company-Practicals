using HimanshuPracticalAPI.DBModels;
using System.ComponentModel.DataAnnotations;

namespace HimanshuPracticalAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int EducationId { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
