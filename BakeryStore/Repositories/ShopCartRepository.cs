using BakeryStore.Database;
using BakeryStore.Models;
using BakeryStore.Repositories;
using Microsoft.EntityFrameworkCore;

public class ShopCartRepository : IShopCart
{
    private readonly AppDBContent _appDBContent;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ShopCartRepository(AppDBContent appDBContent, IHttpContextAccessor httpContextAccessor)
    {
        _appDBContent = appDBContent;
        _httpContextAccessor = httpContextAccessor;
    }

    public string ShopCartId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<ShopCartItem> ShopItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void AddToCart(Product product, int quantity)
    {
        var shopCartId = GetCartId();
        var existingItem = _appDBContent.ShopCartItem.SingleOrDefault(item => item.ShopCartId == shopCartId && item.ProductId == product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var newItem = new ShopCartItem
            {
                ShopCartId = shopCartId,
                ProductId = product.Id,
                Quantity = quantity,
                Price = (int)product.Price
            };
            _appDBContent.ShopCartItem.Add(newItem);
        }

        _appDBContent.SaveChanges();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteFromCart(int id)
    {
        var shopCartId = GetCartId();
        var item = _appDBContent.ShopCartItem.SingleOrDefault(item => item.ShopCartId == shopCartId && item.ProductId == id);

        if (item != null)
        {
            _appDBContent.ShopCartItem.Remove(item);
            _appDBContent.SaveChanges();
        }
    }

    public ShopCartItem GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public List<ShopCartItem> GetShopItems()
    {
        var shopCartId = GetCartId();
        return _appDBContent.ShopCartItem
            .Where(item => item.ShopCartId == shopCartId)
            .Include(item => item.Product)
            .ToList();
    }

    public int[] GetShopItemsIds()
    {
        throw new NotImplementedException();
    }

    private string GetCartId()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartId = session.GetString("CartId");

        if (cartId == null)
        {
            cartId = Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
        }

        return cartId;
    }
}
