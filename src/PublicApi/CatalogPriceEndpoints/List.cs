using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//Added for price filter support
namespace Microsoft.eShopWeb.PublicApi.CatalogPriceEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListCatalogPricesResponse>
    {
        private readonly IRepository<CatalogPrice> _catalogPriceRepository;
        private readonly IMapper _mapper;

        public List(IRepository<CatalogPrice> catalogPriceRepository,
            IMapper mapper)
        {
            _catalogPriceRepository = catalogPriceRepository;
            _mapper = mapper;
        }

        [HttpGet("api/catalog-prices")]
        [SwaggerOperation(
            Summary = "List Catalog Prices",
            Description = "List Catalog Prices",
            OperationId = "catalog-types.List",
            Tags = new[] { "CatalogTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListCatalogPricesResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListCatalogPricesResponse();

            var items = await _catalogPriceRepository.ListAsync(cancellationToken);

            response.CatalogTypes.AddRange(items.Select(_mapper.Map<CatalogPriceDto>));

            return Ok(response);
        }
    }
}
