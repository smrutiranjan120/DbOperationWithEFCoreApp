using DbOperationWithEFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController (AppDbContext appDbContext): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] Book newBook)
        {
            await appDbContext.Books.AddAsync(newBook);
            await appDbContext.SaveChangesAsync();
            return Ok(newBook);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBooks([FromBody] List<Book> books)
        {
            await appDbContext.Books.AddRangeAsync(books);
            await appDbContext.SaveChangesAsync();
            return Ok(books);
        }
    }
}
