
namespace Catalog.API.Products.GetProducts
{

    public record GetProductRequest(int? PageNumber=1 , int? PageSize =10);
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {   
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // "/products" endpoint'i tanımlanıyor, HTTP GET isteği ile çalışır.
            app.MapGet("/products", async ([AsParameters] GetProductRequest request , ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                // MediatR kullanılarak GetProductsQuery gönderiliyor ve ürünler alınıyor.
                var result = await sender.Send(query);
                // Sonuç, GetProductResponse tipine dönüştürülüyor (Mapster ile).
                var response = result.Adapt<GetProductResponse>();
                // 200 OK ile birlikte response döndürülüyor.
                return Results.Ok(response);
            })
            // Endpoint'e "GetProducts" ismi veriliyor (link generation ve dokümantasyon için).
            .WithName("GetProducts")
            // 200 OK durumunda GetProductResponse tipinde veri döneceği belirtiliyor.
            .Produces<GetProductResponse>(StatusCodes.Status200OK)
            // 400 BadRequest durumunda problem detayları döneceği belirtiliyor.
            .ProducesProblem(StatusCodes.Status400BadRequest)
            // Endpoint'in kısa özeti ekleniyor (Swagger/OpenAPI için).
            .WithSummary("Get all products")
            // Endpoint'in açıklaması ekleniyor (Swagger/OpenAPI için).
            .WithDescription("Get all products from database");
        }
    }
}
