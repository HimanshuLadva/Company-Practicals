﻿namespace HimanshuPracticalAPI.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public int EducationId { get; set; }
        //public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
