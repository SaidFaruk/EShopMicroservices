using Marten.Schema;
using System.Runtime.CompilerServices;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            session.Store<Product>(GetPreconfiguredProucts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProucts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = new Guid("b366f940-7f65-4d35-b2ad-0b542911cea6"),
                    Name = "IPhone X",
                    Category = new List<string>(){"Smart Phone"},
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    ImageFile = "product-1.png",
                    Price = 950.00M
                }
              
            };
        }
    }
}
