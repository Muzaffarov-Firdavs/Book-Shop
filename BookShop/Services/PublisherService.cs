using BookShop.DTOs;
using BookShop.Exceptions;
using BookShop.Interfaces;
using BookShop.Repositories;
using BookShop.Domain.Entities;

namespace BookShop.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> repository;

        public PublisherService(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }

        public async Task<CommonResultDto> AddAsync(PublisherCreationDto dto)
        {
            var entity = await this.repository.SelectAsync(p => p.Name == dto.Name);
            if (entity is not null)
                throw new CustomException(409, "Already exist.");

            var mappedEntity = new Publisher
            {
                Name = dto.Name,
            };

            var result = await this.repository.CreateAsync(mappedEntity);
            return new CommonResultDto { Id = result.Id };
        }
    }
}
