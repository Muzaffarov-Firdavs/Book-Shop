using BookShop.DTOs;
using BookShop.Exceptions;
using BookShop.Interfaces;
using BookShop.Repositories;
using BookShop.Domain.Entities;

namespace BookShop.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> repository;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Publisher> publisherRepository;
        private readonly IRepository<Discount> discountRepository;

        public BookService(IRepository<Book> repository,
            IRepository<Author> authorRepository,
            IRepository<Publisher> publisherRepository,
            IRepository<Discount> discountRepository)
        {
            this.repository = repository;
            this.authorRepository = authorRepository;
            this.publisherRepository = publisherRepository;
            this.discountRepository = discountRepository;
        }

        public async Task<CommonResultDto> AddAsync(BookCreationDto dto)
        {
            var entity = await this.repository.SelectAsync(p => p.Name == dto.Name);
            if (entity is not null)
                throw new CustomException(409, "Already exist.");

            var author = await this.authorRepository.SelectAsync(p => p.Id == dto.AuthorId);
            if (author is null)
                throw new CustomException(404, "Author not found.");

            var publisher = await this.publisherRepository.SelectAsync(p => p.Id == dto.PublisherId);
            if (publisher is null)
                throw new CustomException(404, "Publisher not found.");

            var mappedEntity = new Book
            {
                Name = dto.Name,
                AuthorId = dto.AuthorId,
                PublisherId = dto.PublisherId,
                Price = dto.Price,
                Year = dto.Year,
            };

            var result = await this.repository.CreateAsync(mappedEntity);
            return new CommonResultDto { Id = result.Id };
        }

        public async Task<IEnumerable<BookResultDto>> RetriewAllAsync(string? name, string? author, string? publisher,
            decimal? priceFrom, decimal? priceTo, string? genre)
        {
            var entities = (await this.repository.SelectAllAsync()).ToList();

            // Filter data
            if (!string.IsNullOrEmpty(name))
                entities = entities.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrEmpty(author))
                entities = entities.FindAll(p => p.Author.Name.ToLower().Contains(author.ToLower()));
            
            if (!string.IsNullOrEmpty(publisher))
                entities = entities.FindAll(p => p.Publisher.Name.ToLower().Contains(publisher.ToLower()));

            if (!string.IsNullOrEmpty(genre))
                entities = entities.FindAll(p => p.Genre.Name.ToLower().Contains(genre.ToLower()));

            if (priceFrom is not null || priceFrom != 0)
                entities = entities.FindAll(p => p.Price > priceFrom);

            if (priceTo is not null || priceTo != 0)
                entities = entities.FindAll(p => p.Price < priceTo);


            var results = new List<BookResultDto>();
            foreach (var entity in entities)
            {
                int discount = 0;

                var discountBook = await this.discountRepository.SelectAsync(p => p.BookId == entity.Id);
                if (discountBook is not null)
                    discount = discountBook.Percentage;

                var discountAuthor = await this.discountRepository.SelectAsync(p => p.AuthorId == entity.AuthorId);
                if (discountAuthor is not null && discount < discountAuthor.Percentage)
                    discount = discountAuthor.Percentage;

                var discountPublisher = await this.discountRepository.SelectAsync(p => p.PublisherId == entity.PublisherId);
                if (discountPublisher is not null && discount < discountPublisher.Percentage)
                    discount = discountPublisher.Percentage;

                decimal realPrice;
                if (discount != 0)
                {
                    realPrice = (1 - discount / entity.Price) * 100;
                }
                else
                {
                    realPrice = entity.Price;
                }

                var mappedEntity = new BookResultDto
                {
                    Name = entity.Name,
                    AuthorId = entity.AuthorId,
                    PublisherId = entity.PublisherId,
                    Price = realPrice,
                    Year = entity.Year,
                };
                results.Add(mappedEntity);
            }

            return results;
        }
    }
}
