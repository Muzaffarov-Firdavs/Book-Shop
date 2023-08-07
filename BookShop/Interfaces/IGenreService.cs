using BookShop.DTOs;

namespace BookShop.Interfaces
{
    public interface IGenreService
    {
        Task<CommonResultDto> AddAsync(GenreCreationDto dto);
    }
}
