using eCommerce.Application.Services;
using eCommerce.Domain;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Mvc.UI.Areas.Carts.Controllers;

[Area("Carts")]
public class HomeController(CartsService _cartsService, CartItemsService _cartItemsService, CommonQueriesService _commonQueriesService) : Controller
{
    public async Task<IActionResult> YourCart()
    {
        var myCartItems = await _commonQueriesService.GetYourCartItemsAsync(Convert.ToInt32(HttpContext.Session.GetInt32("CartId")));
        return View(myCartItems);
    }
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1, int size = 7)
    {
        if (HttpContext.Session.GetInt32("CartId") == null)
        {
            Cart cart = new Cart()
            {
                CartDate = DateTime.Now,
                CustomerId = 1
            };
            await _cartsService.CreateNewCart(cart);
            HttpContext.Session.SetInt32("CartId", cart.CartId);
        }
        CartItem cartItem = new CartItem()
        {
            CartId = Convert.ToInt32(HttpContext.Session.GetInt32("CartId")),
            ProductId = productId,
            Quantity = quantity,
            Size = size
        };
        int result = await _cartItemsService.AddNewCartItem(cartItem);
        if (result > 0)
        {
            return RedirectToAction("YourCart");
        }
        return View();
    }
}
