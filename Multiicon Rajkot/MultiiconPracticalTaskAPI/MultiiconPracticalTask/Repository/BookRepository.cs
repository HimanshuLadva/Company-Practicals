using Microsoft.EntityFrameworkCore;
using MultiiconPracticalTask.DBModels;
using MultiiconPracticalTask.Models;
using System.Security.Claims;

namespace MultiiconPracticalTask.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly UserBookDBContext _dBContext;
        private readonly IBaseRepository _baseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookRepository(UserBookDBContext dBContext, IBaseRepository baseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dBContext = dBContext;
            _baseRepository = baseRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddBook(BookModel model)
        {
            var appUserID = _baseRepository.GetUserId();
            var data = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                UserId = Convert.ToInt32(appUserID),
            };

            await _dBContext.Books.AddAsync(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBook(int Id, BookModel model)
        {
            var appUserID = _baseRepository.GetUserId();
            var data = await _dBContext.Books.FindAsync(Id);
            if (data == null)
            {
                return false;
            }

            data.Title = model.Title;
            data.Author = model.Author;
            data.Description = model.Description;
            data.CreatedDate = data.CreatedDate;
            data.UpdatedDate = DateTime.Now;
            data.UpdaterId = Convert.ToInt32(appUserID);

            _dBContext.Books.Update(data);
            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<BookModel> GetBookById(int Id)
        {
            var data = await _dBContext.Books.FindAsync(Id);

            var result = new BookModel()
            {
                Title = data!.Title,
                Author = data.Author,
                Description = data.Description,
                CreatedDate = data.CreatedDate,
            };

            return result;
        }
        public async Task<List<BookModel>> GetAllBook()
        {
            var appUserID = _baseRepository.GetUserId();
            var user = await _dBContext.Users.FindAsync(Convert.ToInt32(appUserID));
            var result = new List<BookModel>();

            if (user!.IsAdmin)
            {
                result = await _dBContext.Books.Where(x => x.IsDeleted == false).Select(data => new BookModel()
                {
                    Id = data.Id,
                    Title = data!.Title,
                    Author = data.Author,
                    Description = data.Description,
                    CreatedDate = data.CreatedDate,
                }).ToListAsync();
            }
            else
            {
                result = await _dBContext.Books.Where(x => x.IsDeleted == false && x.UserId == Convert.ToInt32(appUserID)).Select(data => new BookModel()
                {
                    Id = data.Id,
                    Title = data!.Title,
                    Author = data.Author,
                    Description = data.Description,
                    CreatedDate = data.CreatedDate,
                }).ToListAsync();
            }

            return result;
        }

        public async Task<bool> DeleteBook(int Id)
        {
            var appUserID = _baseRepository.GetUserId();
            var data = await _dBContext.Books.FindAsync(Id);
            if (data == null) return false;

            data.IsDeleted = true;
            data.UpdaterId = Convert.ToInt32(appUserID);
            _dBContext.Books.Update(data);
            await _dBContext.SaveChangesAsync();

            return true;
        }
    }
}
