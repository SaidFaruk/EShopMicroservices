namespace Catalog.API.Products.DeleteProduct
{
    public record class DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record class DeleteProductResult(bool IsSuccess);
 
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling {Command} ", command);
             session.Delete<Product>(command.Id);
            
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
    
}
