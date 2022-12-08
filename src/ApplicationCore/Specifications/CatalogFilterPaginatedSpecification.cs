using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId, int? priceId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                //Added code to include the priceId
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) &&
                (!priceId.HasValue || i.CatalogPriceId == priceId))
                .Skip(skip).Take(take);
        }
    }
}
