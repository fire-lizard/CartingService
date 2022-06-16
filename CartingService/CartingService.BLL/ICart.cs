using System.Collections.Generic;
using CartingService.DAL;

namespace CartingService.BLL
{
    public interface ICart
    {
        IEnumerable<CartItem> GetItems();
        void AddItem(CartItem item, int quantity);
        void RemoveItem(CartItem item, int quantity);
    }
}
