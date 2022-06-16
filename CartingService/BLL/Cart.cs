using System;
using System.Collections.Generic;
using CartingService.DAL;

namespace CartingService.BLL
{
    /// <summary>
    /// Cart class
    /// </summary>
    public class Cart : ICart
    {
        public Cart(Guid guid)
        {
            Id = guid;
            _items = new List<CartItem>();
        }

        private IEnumerable<CartItem> _items;

        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>The items.</returns>
        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="quantity">Quantity.</param>
        public void AddItem(CartItem item, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="quantity">Quantity.</param>
        public void RemoveItem(CartItem item, int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}
