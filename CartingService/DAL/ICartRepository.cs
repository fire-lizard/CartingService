using System;
using System.Collections.Generic;
using LiteDB;

namespace CartingService.DAL
{
    public interface ICartRepository
    {
        ILiteDatabase GetDatabase();
        Cart GetCart(Guid cartId);
        ICollection<CartItem> GetItems(Guid cartId);
    }
}
