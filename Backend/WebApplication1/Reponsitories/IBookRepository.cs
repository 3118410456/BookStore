using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Reponsitories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBookAsync();
        public Task<BookModel> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(BookModel model);
        public Task UpdateBookAsync(int id , BookModel model);
    }
}
