using System.ComponentModel.DataAnnotations;

namespace HimanshuPractIcalTaskBE.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Education { get; set; }
        public string? Website { get; set; }
        public string? GitLink { get; set; }
    }
}
