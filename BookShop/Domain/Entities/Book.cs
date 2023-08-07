using BookShop.Domain.Commons;

namespace BookShop.Domain.Entities
{
    public class Book : Auditable
    {
        public string Name { get; set; }
        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public long GenreId { get; set; }
        public Genre Genre { get; set; }

        public DateTime Year { get; set; }
        public decimal Price { get; set; }

    }
}
