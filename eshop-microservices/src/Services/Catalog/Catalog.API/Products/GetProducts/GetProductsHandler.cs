namespace Catalog.API.Products.GetProducts
{



    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger):IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        /*
         
         Idocumentsession bir marten arayüzüdür ve veritabanı işlemlerini gerçekleştirmek için kullanılır.
            Marten, PostgreSQL veritabanı üzerinde çalışan bir belge veritabanı ve olay kaydı kitaplığıdır.
            Idocumentsession, Marten ile etkileşimde bulunmak için kullanılan temel bileşenlerden biridir.
            Bu arayüz, belge ekleme, güncelleme, silme ve sorgulama gibi işlemleri gerçekleştirmek için çeşitli yöntemler sağlar.
            Marten, .NET uygulamalarında belge tabanlı veritabanı işlemlerini kolaylaştırmak için kullanılır ve Idocumentsession, bu işlemleri gerçekleştirmek için kullanılan ana araçtır.
            1. Belge Yönetimi: Idocumentsession, belge tabanlı veritabanı işlemlerini yönetmek için kullanılır. Belgeler, JSON formatında saklanır ve bu arayüz aracılığıyla belgeleri ekleyebilir, güncelleyebilir veya silebilirsiniz.
            2. Sorgulama: Idocumentsession, veritabanında sorgular yapmanıza olanak tanır. LINQ (Language Integrated Query) kullanarak belgeleri sorgulayabilir ve filtreleyebilirsiniz.
         Iqueryhandler ise mediatR kütüphanesinden gelir ve sorgu işlemlerini yönetmek için kullanılır.
        handle metodu ise sorguyu işlemek ve sonuçları döndürmek için kullanılır.
        cancellationtoken ise işlemin iptal edilip edilmeyeceğini kontrol etmek için kullanılır.
        cancellationtoken, uzun süren işlemler sırasında kullanıcının işlemi iptal etmesine olanak tanır.
      
         */
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler called with query: {@query}", query);
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
        
            return new GetProductsResult(products);
        }
    }
    
}
