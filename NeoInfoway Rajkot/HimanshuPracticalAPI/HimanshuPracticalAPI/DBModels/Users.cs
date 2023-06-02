namespace HimanshuPracticalAPI.DBModels
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class Education
    {
        public int Id { get; set; }
        public string EducationName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
