using System;
using System.Collections.Generic;
using LiteDB;

namespace CartingService.DAL
{
    public class CartRepository
    {
        //private ILiteDatabase _db = new LiteDatabase($"/home/{Environment.UserName}/Projects/CartingService/CartingService/Data/cs.db");

        private ILiteDatabase _db =
            new LiteDatabase($"C:\\Users\\{Environment.UserName}\\RiderProjects\\CartingService\\CartingService\\Data\\cs.db");

        public CartRepository()
        {
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _db.GetCollection<CartItem>().FindAll();
        }

        public void AddItem(CartItem item, int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(CartItem item, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
