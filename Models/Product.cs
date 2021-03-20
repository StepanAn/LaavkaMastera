namespace MyShop.Models
{
    public class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int IsFavorite { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
