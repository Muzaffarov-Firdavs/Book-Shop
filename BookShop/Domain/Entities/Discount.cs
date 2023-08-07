using BookShop.Domain.Commons;

namespace BookShop.Domain.Entities
{
    public class Discount : Auditable
    {
        public long? BookId { get; set; }
        public Book Book { get; set; }

        public long? AuthorId { get; set; }
        public Author Author { get; set; }

        public long? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
