using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using UI.ExtensionMethods;

namespace UI.Services
{
    public class CartSessionService : ICartSessionService
    {
        IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContecAccessor)
        {
            _httpContextAccessor = httpContecAccessor;
        }

        public Cart GetCart()
        {
           Cart cartToCheck= _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck= _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart",cart);
        }
    }
}
