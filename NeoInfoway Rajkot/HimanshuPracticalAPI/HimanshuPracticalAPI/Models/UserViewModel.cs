﻿using System.ComponentModel.DataAnnotations;

namespace HimanshuPracticalAPI.Models
{
    public class UserViewModel
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
        public int GenderId { get; set; }

        [Required]
        public string Education { get; set; }
    }
}
