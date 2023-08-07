using BookShop.DTOs;

namespace BookShop.Interfaces
{
    public interface IBookService
    {
        Task<CommonResultDto> AddAsync(BookCreationDto dto);
        Task<IEnumerable<BookResultDto>> RetriewAllAsync(
            string? name, string? author, string? publisher,
            decimal? priceFrom, decimal? priceTo, string? genre);
    }
}
