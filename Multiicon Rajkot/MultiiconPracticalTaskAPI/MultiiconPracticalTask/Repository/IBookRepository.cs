using Microsoft.EntityFrameworkCore;
using MultiiconPracticalTask.DBModels;
using MultiiconPracticalTask.Models;

namespace MultiiconPracticalTask.Repository
{
    public interface IBookRepository
    {
        Task<bool> AddBook(BookModel model);
        Task<bool> UpdateBook(int Id, BookModel model);
        Task<BookModel> GetBookById(int Id);
        Task<List<BookModel>> GetAllBook();
        Task<bool> DeleteBook(int Id);
    }
}