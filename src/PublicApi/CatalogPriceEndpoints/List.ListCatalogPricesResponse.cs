using System;
using System.Collections.Generic;

//Added for price filter functionality
namespace Microsoft.eShopWeb.PublicApi.CatalogPriceEndpoints
{
    public class ListCatalogPricesResponse : BaseResponse
    {
        public ListCatalogPricesResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListCatalogPricesResponse()
        {
        }

        public List<CatalogPriceDto> CatalogTypes { get; set; } = new List<CatalogPriceDto>();
    }
}
