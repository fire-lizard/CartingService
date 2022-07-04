using System;
using System.Collections.Generic;
using LiteDB;

namespace CartingService.DAL
{
    public class CartRepository : ICartRepository
    {
        //private ILiteDatabase _db =
        //    new LiteDatabase($"/home/{Environment.UserName}/Projects/CartingService/CartingService/Data/cs.db");

        private readonly string _dbPath =
            $"C:\\Users\\{Environment.UserName}\\RiderProjects\\CartingService\\CartingService\\Data\\cs.db";

        
        public ILiteDatabase GetDatabase()
        {
            return new LiteDatabase(_dbPath);
        }
        
        public Cart GetCart(Guid cartId)
        {
            using (var db = GetDatabase())
            {
                var cart = db.GetCollection<Cart>().FindById(cartId);
                return cart;
            }
        }

        public ICollection<CartItem> GetItems(Guid cartId)
        {
            using (var db = GetDatabase())
            {
                var cart = db.GetCollection<Cart>().FindById(cartId);
                return cart?.Items;
            }
        }
    }
}
