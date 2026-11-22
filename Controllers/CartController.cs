using System.Text.Json;
using EcommerceWebsite.Data;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Controllers;

public class CartController(StoreDbContext db) : Controller
{
    private const string CartKey = "SHOPPING_CART";
    private List<CartItem> GetCart() => JsonSerializer.Deserialize<List<CartItem>>(HttpContext.Session.GetString(CartKey) ?? "[]") ?? [];
    private void SaveCart(List<CartItem> cart) => HttpContext.Session.SetString(CartKey, JsonSerializer.Serialize(cart));

    public IActionResult Index() => View(GetCart());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId)
    {
        var product = await db.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if (product is null) return NotFound();
        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
            cart.Add(new CartItem { ProductId = product.Id, Name = product.Name, Price = product.Price, ImageUrl = product.ImageUrl, Quantity = 1 });
        else if (item.Quantity < product.Stock)
            item.Quantity++;
        SaveCart(cart);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Remove(int productId)
    {
        var cart = GetCart();
        cart.RemoveAll(x => x.ProductId == productId);
        SaveCart(cart);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        SaveCart([]);
        return RedirectToAction(nameof(Index));
    }
}
