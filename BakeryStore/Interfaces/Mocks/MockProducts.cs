using BakeryStore.Models;

namespace BakeryStore.Interfaces.Mocks
{
    public class MockProducts : IProducts
    {
        private List<Product> _products;
        private ICategories categories;

        public MockProducts() 
        { 
            _products = new List<Product>();
            categories = new MockCategories();

            GenerateData();
        }

        public Product GetProductById(int id)
        {
            return _products.Where(product => product.Id == id).First();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        private void GenerateData() 
        {
            Product product1 = new Product {
                Id = 1,
                Title = "Горішок",
                Photo = "https://bakerstreetbakery.com.ua/files/resized/products/689.1900x1900.jpg",
                Description = "Торт-комбо з улюбленого торта жителів та гостей столиці та \"саме тих\" горішків з дитинства. Легкі коржі безе із фундуком та улюблений крем із вареним згущеним молоком",
                Price = decimal.Parse("600"),
                Stuff = "молоко згущене варене 8,5% МОЛОКО КОРОВ‛ЯЧЕ, цукор білий кристалічний( не менше 43.5%), МОЛОЧНИЙ ЦУКОР (ЛАКТОЗА)\r\nМАСЛО СОЛОДКОВЕРШКОВЕ 72,5%\r\nцукрова пудра\r\nФУНДУК\r\nБІЛОК ЯЄЧНИЙ\r\nБОРОШНО ПШЕНИЧНЕ В/Г\r\nСИР ВЕРШКОВИЙ 65% КРЕМЕТТЕ сир кисломолочний,згущувач: модифіко ваний крохмаль, стабілізатори: камідь рожкового дерева, гуарова камідь\r\nМОЛОКО КОРОВ’ЯЧЕ НЕЗБИРАНЕ ЗГУЩЕНЕ 8,5% (МОЛОКО КОРОВ‛ЯЧЕ, цукор білий кристалічний ( не менше 43.5%), МОЛОЧНИЙ ЦУКОР ( ЛАКТОЗА)).\r\nЖОВТОК ЯЄЧНИЙ\r\nкрохмаль кукурудзяний\r\nсіль",
                Calories = "Калорійність ккал: 434.06\r\nКалорійність кДж: 1817.31\r\nЖири: 29.28\r\nНасичені жири: 16.27\r\nВуглеводи: 36.87\r\nЦукор: 31.51\r\nБілки: 5.77\r\nСіль: 0.23",
                Weight = 0.6,
                ShelfLife = 3,
                StorageConditions = "при температурі від +2 до +6˚С",
                isFavourite = false,
                Available = true,
                Category = categories.GetCategory(2)
            };

            Product product2 = new Product
            {
                Id = 2,
                Title = "Мохіто міні",
                Photo = "https://bakerstreetbakery.com.ua/files/resized/products/694.1900x1900.jpg",
                Description = "Позасезонний фаворит - торт Мохіто у своїй міні-версії. В ньому тонкий мигдалевий бісквіт, найароматніший м'ятно-лаймовий крем та сезонні ягоди.",
                Price = decimal.Parse("500"),
                Stuff = "ШОКОЛАД БІЛИЙ цукор, какао-масло, МОЛОКО сухе незбиране, МОЛОКО сухе знежирене, еквівалент какао-масла (негідрогенізовані пальмова олія, олія ши, олія ілліпе), жир МОЛОЧНИЙ,емульгатори(СОЄВИЙ лецитин Е476),ароматизатор\r\nполуниця свіжа\r\nВЕРШКИ З КОРОВ’ЯЧОГО МОЛОКА 30%\r\nцукор білий\r\nМИГДАЛЬ СИРИЙ\r\nБІЛОК ЯЄЧНИЙ\r\nЖОВТОК ЯЄЧНИЙ\r\nсік лимона\r\nвода підготовлена\r\nсік лайма\r\nмята\r\nкрохмаль кукурудзяний\r\nцедра лайма\r\nрозпушувач\r\nжеле для торта DR.OETKER цукор,загущувач: карагенан Е407, стабілізатор: бітартрат калію Е336і, желеутворювач: камедь рожкового дерева Е410, желюючий агент(хлорид калію(Е508)).",
                Calories = "Калорійність ккал: 347.46\r\nКалорійність кДж: 1454.74\r\nЖири: 21.32\r\nНасичені жири: 11.75\r\nВуглеводи: 33.65\r\nЦукор: 32.35\r\nБілки: 5.25\r\nСіль: 0.18",
                Weight = 0.5,
                ShelfLife = 3,
                StorageConditions = "при температурі від +2 до +6˚С",
                isFavourite = false,
                Available = true,
                Category = categories.GetCategory(2)
            };

            Product product3 = new Product
            {
                Id = 3,
                Title = "Пряник контурний Mickey & Minnie Mouse",
                Photo = "https://bakerstreetbakery.com.ua/files/resized/products/984.1900x1900.jpg",
                Description = "",
                Price = decimal.Parse("55"),
                Stuff = "БОРОШНО ПШЕНИЧНЕ В/Г\r\nмед\r\nцукор білий\r\nМАСЛО СОЛОДКОВЕРШКОВЕ 72,5%\r\nБІЛОК ЯЄЧНИЙ\r\nцукрова пудра\r\nЖОВТОК ЯЄЧНИЙ\r\nкориця мелена\r\nцукор ванільний\r\nімбир мелений\r\nрозпушувач\r\nсік лимона\r\nмускатний горіх\r\nгвоздика мелена\r\nкоріандр",
                Calories = "Калорійність ккал: 364.58\r\nКалорійність кДж: 1526.42\r\nЖири: 9.37\r\nНасичені жири: 5.9\r\nВуглеводи: 64.36\r\nЦукор: 32.52\r\nБілки: 5.72\r\nСіль: 0.04",
                Weight = 0.04,
                ShelfLife = 45,
                StorageConditions = "при температурі не вище +25˚С і вологості не більше 65%",
                isFavourite = false,
                Available = true,
                Category = categories.GetCategory(1)
            };

            Product product4 = new Product
            {
                Id = 4,
                Title = "Іриска банан",
                Photo = "https://bakerstreetbakery.com.ua/files/resized/products/809.1900x1900.jpg",
                Description = "Вершкова іриска з в'яленим бананом",
                Price = decimal.Parse("25"),
                Stuff = "МАСЛО СОЛОДКОВЕРШКОВЕ 82,5%\r\nВЕРШКИ З КОРОВ’ЯЧОГО МОЛОКА 30%\r\nцукор білий\r\nглюкоза\r\nбанан вялений\r\nцукор ванільний\r\nсіль",
                Calories = "Калорійність ккал: 453.8\r\nКалорійність кДж: 1899.98\r\nЖири: 31.56\r\nНасичені жири: 28.78\r\nВуглеводи: 41.21\r\nЦукор: 35.35\r\nБілки: 1.23\r\nСіль: 0.44",
                Weight = 0.02,
                ShelfLife = 30,
                StorageConditions = "при температурі від +2 до +6˚С",
                isFavourite = false,
                Available = true,
                Category = categories.GetCategory(3)
            };

            _products.Add(product1);
            _products.Add(product2);
            _products.Add(product3);
            _products.Add(product4);
        }
    }
}
