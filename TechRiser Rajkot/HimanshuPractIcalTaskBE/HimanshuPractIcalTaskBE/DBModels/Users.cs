namespace HimanshuPractIcalTaskBE.DBModels
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string? Website { get; set; }
        public string? GitLink { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
