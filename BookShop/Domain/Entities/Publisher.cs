using BookShop.Domain.Commons;

namespace BookShop.Domain.Entities
{
    public class Publisher : Auditable
    {
        public string Name { get; set; }
    }
}
