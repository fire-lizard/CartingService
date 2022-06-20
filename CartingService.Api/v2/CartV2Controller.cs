using CartingService.BLL;
using CartingService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api.v2
{
    [ApiController]  
    [ApiVersion("2.0")]  
    [Route("api/v2/cart")]  
    public class CartV2Controller
    {
        [HttpGet]
        public IEnumerable<CartItem>? Get(Guid cartId)
        {
            CartRepository cr = new CartRepository();
            return cr.GetCart(cartId)?.Items;
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