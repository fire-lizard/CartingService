using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using CartingService.DAL;

namespace CartingService.BLL
{
    public class CartRepository : ICartRepository
    {
        //private ILiteDatabase _db =
        //    new LiteDatabase($"/home/{Environment.UserName}/Projects/CartingService/CartingService/Data/cs.db");

        private readonly string _dbPath =
            $"C:\\Users\\{Environment.UserName}\\RiderProjects\\CartingService\\CartingService\\Data\\cs.db";

        public Cart GetCart(Guid cartId)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var cart = db.GetCollection<Cart>().FindById(cartId);
                return cart;
            }
        }

        public ICollection<CartItem> GetItems(Guid cartId)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var cart = db.GetCollection<Cart>().FindById(cartId);
                return cart?.Items;
            }
        }

        public void AddItem(Guid cartId, CartItem item)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var carts = db.GetCollection<Cart>();
                var cart = carts.FindById(cartId);
                if (cart == null)
                {
                    carts.Insert(new Cart {CartId = cartId, Items = new[]{item}});
                    carts.EnsureIndex(x => x.CartId);
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
            using (var db = new LiteDatabase(_dbPath))
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
