using System;
using System.Linq;
using LiteDB;
using CartingService.DAL;

namespace CartingService.BLL
{
    public class CartBusinessObject
    {
        public void AddItem(Guid cartId, CartItem item)
        {
            CartRepository cr = new CartRepository();
            using (var db = cr.GetDatabase())
            {
                var carts = db.GetCollection<Cart>();
                var cart = carts.FindById(cartId);
                if (cart == null)
                {
                    carts.Insert(new Cart { Id = cartId, Items = new[] { item } });
                    carts.EnsureIndex(x => x.Id);
                }
                else
                {
                    cart.Items.Add(item);
                    carts.Update(cartId, cart);
                }
            }
        }

        public void RemoveItem(Guid cartId, int itemId)
        {
            CartRepository cr = new CartRepository();
            using (var db = cr.GetDatabase())
            {
                var carts = db.GetCollection<Cart>();
                var cart = carts.FindById(cartId);
                if (cart == null)
                {
                    throw new Exception("Cart with specified ID does not exist");
                }

                var cartItem = cart.Items.FirstOrDefault(x => x.Id == itemId);
                cart.Items.Remove(cartItem);
                carts.Update(cartId, cart);
            }
        }
    }
}
