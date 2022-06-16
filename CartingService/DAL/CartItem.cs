using System.ComponentModel.DataAnnotations;

namespace CartingService.DAL
{
    /// <summary>
    /// Cart item.
    /// </summary>
    public class CartItem
    {
        public CartItem(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Identifier
        /// </summary>
        [Required]
        public int Id { get; private set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public ItemImage Image { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        public int Quantity { get; set; }
    }
}
