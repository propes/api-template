using System.Globalization;
using ApiTemplate.Shared;

namespace ApiTemplate.Endpoints;

public class GetProductsEndpoint() : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "api/products",
            (
                int page = 1,
                int pageSize = 10,
                string? sortBy = null,
                string? sortDirection = null,
                string? sku = null,
                string? name = null,
                decimal? price = null
            ) =>
            {
                var filteredProducts = _products
                    .Where(p => sku == null || p.Id == sku)
                    .Where(p =>
                        name == null || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                    )
                    .Where(p => price == null || p.Price == price)
                    .OrderBy(p =>
                        sortBy switch
                        {
                            "name" => p.Name,
                            "price" => p.Price.ToString(CultureInfo.InvariantCulture),
                            _ => p.Id.ToString(),
                        }
                    )
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToArray();

                return Results.Json(filteredProducts);
            }
        );
    }

    private readonly Product[] _products =
    [
        new()
        {
            Id = "1",
            Name = "Product 1",
            Price = 10.00m,
        },
        new()
        {
            Id = "2",
            Name = "Product 2",
            Price = 20.00m,
        },
        new()
        {
            Id = "3",
            Name = "Product 3",
            Price = 30.00m,
        },
        new()
        {
            Id = "4",
            Name = "Product 4",
            Price = 40.00m,
        },
        new()
        {
            Id = "5",
            Name = "Product 5",
            Price = 50.00m,
        }
    ];
}


public class Product
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}
