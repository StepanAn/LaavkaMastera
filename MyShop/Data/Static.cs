using MyShop.Models;
using System.Collections.Generic;

namespace MyShop.Data
{
    public class Static
    {
        public static List<CartItem> Cart = new();
        public static bool IAdmin = false;
        public const int Password = 1111;
        public static int ItemId = 1;
        public static List<Category> Categories;
        public static Category[] Cats = new Category[3] {
            new Category()
            {
                CategoryName = "Букеты",
            },
            new Category()
            {
                CategoryName = "Красивые подарки",
            },
            new Category()
            {
                CategoryName = "Торты",
            },
        };
        public static Product[] Products = new Product[5] {
        new Product() {
            Img = "/img/20151215_130851.png",
            Name = "Украшенное шампанское",
            LongDesc = @"
            Украшение шампанского к Новому году. 
            Для украшения используются мелкие новогодние игрушки, конфеты, ленты, веточки. 
            На фото украшение В НАЛИЧИИ☝!!! 
            ",
            Price = 700,
            Category = Static.Cats[1],
        },
        new Product()
        {
            Img = "/img/20151211_115740.png",
            Price = 500,
            Name = "Украшенная упаковка рафаэлло",
            LongDesc = @"
            Прекрасно оформленная упаковка рафаэлло.
            Она подойдёт в качестве подарка к новуму году,
            дню рождению, свадьбе и другим праздникам.
            ",
            Category = Static.Cats[1],
        },
        new Product()
        {
            Img = "/img/DSC_0750.png",
            Price = 1000,
            Name = "Шампанское Лев Голицын с кофе",
            LongDesc = @"
            Бутылка шампанского Лев голицын с пачкой кофе,
            лежащих в коробке, оформленной исскуственными
            цветами.
            ",
            Category = Static.Cats[1],
        },
        new Product()
        {
            Img = "/img/flowers2.png",
            Name = "Красивый декоративный букет",
            Price = 300,
            LongDesc = @"
            Красивый букет с бутонами из декоративной бумаги 
            и конфетами рафаэлло и фиреро раше.
            Также он украшен пакетиками с чаем.
            ",
            Category = Static.Cats[0],
        },
        new Product()
        {
            Img = "/img/20150508_075935.jpg",
            Name = "Красивый декоративный торт",
            Price = 500,
            LongDesc = @"
            Декоративный торт украшенный множеством конфет.
            ",
            Category = Static.Cats[2],
        },
        };

    }
}
