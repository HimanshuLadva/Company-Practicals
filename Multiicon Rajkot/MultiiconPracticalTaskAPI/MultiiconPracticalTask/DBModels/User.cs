﻿namespace MultiiconPracticalTask.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public ICollection<Book> Books { get; set; }
    }
}
