using System;
using System.Collections.Generic;

namespace CartingService.DAL
{
    public class Cart
    {
        public Guid Id { get; set; }
        
        public ICollection<CartItem> Items { get; set; }
    }
}