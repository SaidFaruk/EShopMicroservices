
namespace Catalog.API.Products.GetProductByCategory
{

    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();

                // Eğer ürün listesi boşsa 404 döndür
                if (response.Products == null || !response.Products.Any())
                {
                    return Results.NotFound("Belirtilen kategoriye ait ürün bulunamadı.");
                }

                return Results.Ok(response);
            })
                .WithName("GetProductsByCategory")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .WithSummary("Get products by category")
                .WithDescription("Get products by category from database ( bu minimal api icin aciklamadir");
        }
    }
}
