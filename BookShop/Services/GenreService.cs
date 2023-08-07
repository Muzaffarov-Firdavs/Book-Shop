using BookShop.DTOs;
using BookShop.Exceptions;
using BookShop.Interfaces;
using BookShop.Repositories;
using BookShop.Domain.Entities;

namespace BookShop.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> repository;
        public GenreService(IRepository<Genre> repository)
        {
            this.repository = repository;
        }

        public async Task<CommonResultDto> AddAsync(GenreCreationDto dto)
        {
            var entity = await this.repository.SelectAsync(p => p.Name == dto.Name);
            if (entity is not null)
                throw new CustomException(409, "Already exist.");

            var mappedEntity = new Genre
            {
                Name = dto.Name,
            };

            var result = await this.repository.CreateAsync(mappedEntity);
            return new CommonResultDto { Id = result.Id };
        }
    }
}
