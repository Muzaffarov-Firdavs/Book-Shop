using BookShop.DTOs;
using BookShop.Exceptions;
using BookShop.Interfaces;
using BookShop.Repositories;
using BookShop.Domain.Entities;

namespace BookShop.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepository<Discount> repository;
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Discount> publisherRepository;

        public DiscountService(IRepository<Discount> repository,
            IRepository<Book> bookRepository, IRepository<Author> authorRepository,
            IRepository<Discount> publisherRepository)
        {
            this.repository = repository;
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.publisherRepository = publisherRepository;
        }

        public async Task<CommonResultDto> AddAsync(DiscountCreationDto dto)
        {
            if (dto.BookId is not null)
            {
                var book = await this.bookRepository.SelectAsync(p => p.Id == dto.BookId);
                if (book is null)
                    throw new CustomException(404, "Author not found.");
            }

            if (dto.AuthorId is not null)
            {
                var author = await this.authorRepository.SelectAsync(p => p.Id == dto.AuthorId);
                if (author is null)
                    throw new CustomException(404, "Author not found.");
            }

            if (dto.PublisherId is not null)
            {
                var publisher = await this.publisherRepository.SelectAsync(p => p.Id == dto.PublisherId);
                if (publisher is null)
                    throw new CustomException(404, "Publisher not found.");
            }

            var mappedEntity = new Discount
            {
                BookId = dto.BookId,
                AuthorId = dto.AuthorId,
                PublisherId = dto.PublisherId,
                Percentage = dto.Percentage,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            var result = await this.repository.CreateAsync(mappedEntity);
            return new CommonResultDto { Id = result.Id };
        }
    }
}
