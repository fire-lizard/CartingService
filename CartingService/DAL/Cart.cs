using System;
using System.Collections.Generic;

namespace CartingService.DAL
{
    public class Cart
    {
        public Guid CartId { get; set; }
        
        public ICollection<CartItem> Items { get; set; }
    }
}