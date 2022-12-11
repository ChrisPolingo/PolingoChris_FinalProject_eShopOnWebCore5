using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId, int? priceId)
        {
            Query.Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId)&&
                //Added for the price filter feature
                (!priceId.HasValue || i.CatalogPriceId == priceId));
        }
    }
}
