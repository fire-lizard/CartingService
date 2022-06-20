using CartingService.BLL;
using CartingService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api.v1
{
    [ApiController]  
    [ApiVersion("1.0")]  
    [Route("api/v1/cart")]  
    public class CartV1Controller
    {
        [HttpGet]
        public Cart? Get(Guid cartId)
        {
            CartRepository cr = new CartRepository();
            return cr.GetCart(cartId);
        }
        
        [HttpPost]
        public void Post(Guid cartId, CartItem item)
        {
            CartRepository cr = new CartRepository();
            cr.AddItem(cartId, item);
        }
        
        [HttpDelete]
        public void Delete(Guid cartId, int cartItemId)
        {
            CartRepository cr = new CartRepository();
            cr.RemoveItem(cartId, cartItemId);
        }
    }
}