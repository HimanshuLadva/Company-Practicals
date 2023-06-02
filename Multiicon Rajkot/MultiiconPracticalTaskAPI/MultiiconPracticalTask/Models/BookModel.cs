using MultiiconPracticalTask.DBModels;
using System.ComponentModel.DataAnnotations;

namespace MultiiconPracticalTask.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
