using CartingService.BLL;
using CartingService.DAL;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api;

[ApiController]  
[ApiVersion("1")]  
[ApiVersion("2")]  
[Route("api/[controller]")]
public class CartController
{
    private const string _mqName = ".\\Private$\\billpay";
    
    public struct ChangedItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    
    private void ReceiveMessage()
    {
        Type[] arrTypes = {typeof(ChangedItem), typeof(object)};
        MessageQueue mq = new MessageQueue(_mqName);
        mq.Formatter = new XmlMessageFormatter(arrTypes);
        ChangedItem changedItem = (ChangedItem)mq.Receive().Body;
    }
    
    [MapToApiVersion("1")] 
    [HttpGet]
    public ActionResult<Cart?> GetV1(Guid cartId)
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
        
    [MapToApiVersion("2")] 
    [HttpGet]
    public ActionResult<IEnumerable<CartItem>?> GetV2(Guid cartId)
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

    [MapToApiVersion("1")] 
    [MapToApiVersion("2")] 
    [HttpPost]
    public IActionResult Post(Guid cartId, CartItem item)
    {
        CartBusinessObject cbo = new CartBusinessObject();
        try
        {
            cbo.AddItem(cartId, item);
        }
        catch (Exception exc)
        {
            return new BadRequestObjectResult(exc.GetExceptionMessages());
        }

        return new OkResult();
    }
        
    [MapToApiVersion("1")] 
    [MapToApiVersion("2")] 
    [HttpDelete]
    public IActionResult Delete(Guid cartId, int cartItemId)
    {
        CartBusinessObject cbo = new CartBusinessObject();
        try
        {
            cbo.RemoveItem(cartId, cartItemId);
        }
        catch (Exception exc)
        {
            return new BadRequestObjectResult(exc.GetExceptionMessages());
        }

        return new OkResult();
    }
}