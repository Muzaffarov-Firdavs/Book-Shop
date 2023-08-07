using BookShop.Domain.Commons;

namespace BookShop.Domain.Entities
{
    public class Genre : Auditable
    {
        public string Name { get; set; }
    }
}
