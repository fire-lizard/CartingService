using CartingService.BLL;
using CartingService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api.v1
{
    [ApiController]  
    [ApiVersion("1")]  
    [Route("api/v1/[controller]")]  
    public class CartController
    {
        [MapToApiVersion("1")] 
        [HttpGet]
        public ActionResult<Cart?> Get(Guid cartId)
        {
            CartRepository cr = new CartRepository();
            try
            {
                var cart = cr.GetCart(cartId);
                if (cart == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(cart);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.GetExceptionMessages());
            }
        }
        
        [MapToApiVersion("1")] 
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
        
        [MapToApiVersion("1")] 
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