using System;
using System.Collections.Generic;
using CartingService.BLL;
using CartingService.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Api.v2
{
    [ApiController]  
    [ApiVersion("2.0")]  
    [Route("api/{v:apiVersion}/cart")]  
    public class CartV2Controller
    {
        [HttpGet(Name = "GetCartInfo")]
        public IEnumerable<CartItem> Get()
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