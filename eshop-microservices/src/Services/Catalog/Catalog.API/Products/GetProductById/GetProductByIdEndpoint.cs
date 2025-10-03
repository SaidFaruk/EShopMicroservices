
namespace Catalog.API.Products.GetProductById
{

public record GetProductByIdResponse(Product Product);



    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
         {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                
                return Results.Ok(response);
            }).
            WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get product by id")  //api dökümantasyonunda gözükmesi için
            .WithDescription("Get product by id from the catalog"); // api dökümantasyonunda açıklama için  
        }
    }
}
