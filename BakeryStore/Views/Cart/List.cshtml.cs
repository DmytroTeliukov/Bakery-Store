using BakeryStore.Repositories;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeryStore.Views.Cart
{
    public class ListModel : PageModel
    {
        public ShopCart shopCart;
        public void OnGet()
        {
        }
    }
}
