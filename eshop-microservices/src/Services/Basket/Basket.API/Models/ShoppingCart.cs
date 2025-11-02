namespace Basket.API.Models
{
    public class ShoppingCart
    {
   

        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>(); // urun hakkında bilgiler listeleniyor
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity); // toplam fiyat hesaplanıyor


        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart()
        {
          //mapping icin gerekli kısımdır
        }

    }
}
