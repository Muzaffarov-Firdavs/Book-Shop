using BookShop.DTOs;
using BookShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(BookCreationDto dto)
            => Ok(await this.bookService.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? name,
            [FromQuery] string? author, [FromQuery] string? publisher,
             [FromQuery] decimal? priceFrom, [FromQuery] decimal? priceTo, [FromQuery] string? genre)
            => Ok(await this.bookService.RetriewAllAsync(name, author, publisher, priceFrom, priceTo, genre));
    }
}
