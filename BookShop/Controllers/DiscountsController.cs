using BookShop.DTOs;
using BookShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class DiscountsController : BaseController
    {
        private readonly IDiscountService discountService;
        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(DiscountCreationDto dto)
            => Ok(await this.discountService.AddAsync(dto));
    }
}
