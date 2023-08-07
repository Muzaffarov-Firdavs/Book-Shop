using BookShop.DTOs;
using BookShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class PublishersController : BaseController
    {
        private readonly IPublisherService publisherService;
        public PublishersController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PublisherCreationDto dto)
            => Ok(await this.publisherService.AddAsync(dto));
    }
}
