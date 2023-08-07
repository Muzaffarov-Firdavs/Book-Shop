namespace BookShop.DTOs
{
    public class BookCreationDto
    {
        public string Name { get; set; }
        public long AuthorId { get; set; }
        public long PublisherId { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
    }
}
