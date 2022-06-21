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
        public ActionResult<IEnumerable<CartItem>?> Get(Guid cartId)
        {
            CartRepository cr = new CartRepository();
            try
            {
                var cart = cr.GetCart(cartId);
                if (cart == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(cart.Items);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.GetExceptionMessages());
            }
        }
        
        [HttpPost]
        public IActionResult Post(Guid cartId, CartItem item)
        {
            CartRepository cr = new CartRepository();
            try
            {
                cr.AddItem(cartId, item);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.GetExceptionMessages());
            }

            return new OkResult();
        }
        
        [HttpDelete]
        public IActionResult Delete(Guid cartId, int cartItemId)
        {
            CartRepository cr = new CartRepository();
            try
            {
                cr.RemoveItem(cartId, cartItemId);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.GetExceptionMessages());
            }

            return new OkResult();
        }
    }
}