using BookShop.DTOs;
using BookShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class GenresController : BaseController
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(GenreCreationDto dto)
           => Ok(await this.genreService.AddAsync(dto));
    }
}
