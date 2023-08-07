using BookShop.DTOs;

namespace BookShop.Interfaces
{
    public interface IAuthorService
    {
        Task<CommonResultDto> AddAsync(AuthorCreationDto dto);
    }
}
