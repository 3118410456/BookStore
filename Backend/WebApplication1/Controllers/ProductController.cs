using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Reponsitories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public ProductController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _repo.GetAllBookAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByID(int id)
        {
            try
            {
                return Ok(await _repo.GetBookByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BookModel model)
        {
            return Ok(await _repo.AddBookAsync(model));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(int id, BookModel model)
        {
            await _repo.UpdateBookAsync(id, model);
            return Ok();
        }



    }
}
