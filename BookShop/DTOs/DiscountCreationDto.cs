namespace BookShop.DTOs
{
    public class DiscountCreationDto
    {
        public long? BookId { get; set; }

        public long? AuthorId { get; set; }

        public long? PublisherId { get; set; }

        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
