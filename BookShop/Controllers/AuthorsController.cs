using BookShop.DTOs;
using BookShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AuthorCreationDto dto)
            => Ok(await this.authorService.AddAsync(dto));
    }
}
