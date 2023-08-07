using BookShop.DTOs;

namespace BookShop.Interfaces
{
    public interface IPublisherService
    {
        Task<CommonResultDto> AddAsync(PublisherCreationDto dto);
    }
}
