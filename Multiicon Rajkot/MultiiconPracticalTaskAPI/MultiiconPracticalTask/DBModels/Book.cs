namespace MultiiconPracticalTask.DBModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public int UpdaterId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
