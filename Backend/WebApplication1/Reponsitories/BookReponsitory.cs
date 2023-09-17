using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Reponsitories
{
    public class BookReponsitory : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookReponsitory(BookStoreContext context , IMapper mapper) 
        {
             _context = context;
            _mapper = mapper;  
        }
        public async Task<int> AddBookAsync(BookModel model)
        {
            var book = _mapper.Map<Book>(model);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.BookID;
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            var book = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(book);
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task UpdateBookAsync(int id, BookModel model)
        {
            if(id == model.BookModelID)
            {
                var book = _mapper.Map<Book>(model);
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
