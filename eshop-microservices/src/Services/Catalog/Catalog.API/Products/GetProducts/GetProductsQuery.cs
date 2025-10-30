namespace Catalog.API.Products.GetProducts
{
    // GetProductsQuery bir record türüdür. Sorgu (query) nesnesi olarak kullanılır.
    // "IQuery<GetProductsResult>" arayüzünden miras alır, yani bu bir sorgu nesnesidir ve sonucunda GetProductsResult döner.
    // Record'lar C#'ta immutable (değiştirilemez) veri taşıyıcılarıdır, genellikle veri transferi veya CQRS deseninde kullanılır.
    // Record'lar method veya property içermez, sadece veri taşır. Bu yüzden içine breakpoint koyamazsın.
    // GetProductsResult ise sorgunun sonucunda dönecek olan ürün listesini (IEnumerable<Product>) taşır.
    // Yani, GetProductsQuery ile ürünler sorgulanır, GetProductsResult ile sonuç döner.
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
}
