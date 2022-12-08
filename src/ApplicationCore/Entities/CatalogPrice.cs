using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogPrice : BaseEntity, IAggregateRoot
    {
        public string Price { get; private set; }
        public CatalogPrice(string price)
        {
            Price = price;
        }
    }
}
