using System;
using System.Collections.Generic;
using CartingService.DAL;

namespace CartingService.BLL
{
    public interface ICartRepository
    {
        Cart GetCart(Guid cartId);
        ICollection<CartItem> GetItems(Guid cartId);
        void AddItem(Guid cartId, CartItem item);
        void RemoveItem(Guid cartId, int itemId);
    }
}
