using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryStore.Repositories
{
    public class ShopCart
    {
        
        private readonly AppDBContent AppDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.AppDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();

            string shopCartId = session.GetString("CartId") ??
            Guid.NewGuid().ToString();
                                      
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product, int quantity)
        {
            if (Contains(product))
                UpdateProductToCart(product, quantity);
            else
                AddNewProductToCart(product, quantity);
            
            AppDBContent.SaveChanges();

        }

        public List<ShopCartItem> GetShopItems()
        {
            return AppDBContent.ShopCartItem
                .Where(c => c.ShopCartId == ShopCartId)
                .Include(s => s.Product)
                .ToList();
        }

        public int[] GetShopItemsIds()
        {
            return (from item in GetShopItems() select item.Product.Id).ToArray();

        }

        public bool Contains(Product product)
        {
            return GetShopItems().Where(item => item.Product == product).Any();
        }

        public void DeleteFromCart(int id)
        {
            AppDBContent.ShopCartItem.Remove(GetItem(id));
            AppDBContent.SaveChanges();
        }

        public ShopCartItem GetItem(int id)
        {
            return GetShopItems().Where(item => item.ShopCartId == ShopCartId && item.ProductId == id).First();

        }

        public void Clear()
        {
            AppDBContent.RemoveRange(GetShopItems());
            AppDBContent.SaveChanges();
        }

        private void AddNewProductToCart(Product product, int quantity)
        {
            AppDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Product = product,
                Quantity = quantity,
                Price = ((int)product.Price) * quantity
            });
        }

        private void UpdateProductToCart(Product product, int quantity)
        {
            var item = AppDBContent.ShopCartItem.Where(item => item.ShopCartId == ShopCartId && item.ProductId == product.Id).First();
            item.Quantity = quantity;
            item.Price += ((int)product.Price);
        }
    }
}
