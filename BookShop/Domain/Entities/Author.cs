using BookShop.Domain.Commons;

namespace BookShop.Domain.Entities
{
    public class Author : Auditable
    {
        public string Name { get; set; }
    }
}
