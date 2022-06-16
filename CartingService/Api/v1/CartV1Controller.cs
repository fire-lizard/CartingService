using System;
using CartingService.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api.v1
{
    [ApiController]  
    [ApiVersion("1.0")]  
    [Route("api/{v:apiVersion}/cart")]  
    public class CartV1Controller
    {
        [HttpGet(Name = "GetCartInfo")]
        public Cart Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost(Name = "AddItemToCart")]
        public Cart Post()
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete(Name = "DeleteItemFromCart")]
        public Cart Delete()
        {
            throw new NotImplementedException();
        }
    }
}