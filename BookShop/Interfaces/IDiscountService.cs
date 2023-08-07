using BookShop.DTOs;

namespace BookShop.Interfaces
{
    public interface IDiscountService
    {
        Task<CommonResultDto> AddAsync(DiscountCreationDto dto);
    }
}
