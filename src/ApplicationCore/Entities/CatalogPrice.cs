using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class PriceType : BaseEntity, IAggregateRoot
    {
        public string Price { get; private set; }
        public PriceType(string price)
        {
            Price = price;
        }
    }
}
