using System.ComponentModel.DataAnnotations;

namespace HimanshuPractIcalTaskBE.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public int EducationId { get; set; }
        public string? Website { get; set; }
        public string? GitLink { get; set; }
    }
}
