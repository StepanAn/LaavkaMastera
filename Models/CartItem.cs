namespace MyShop.Models
{
    public class CartItem
    {
        public int Amount { get; set; }
        public Product TovarInCart { get; set; }
        public int TotalPrice { get; set; }
        public int Id { get; set; }

    }
}
