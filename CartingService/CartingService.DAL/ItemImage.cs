using System.ComponentModel.DataAnnotations;

namespace CartingService.DAL
{
    /// <summary>
    /// Item image
    /// </summary>
    public class ItemImage
    {
        /// <summary>
        /// Image URL
        /// </summary>
        [Url]
	    public string Url { get; set; }

        /// <summary>
        /// Image Alternative Text
        /// </summary>
        public string AltText { get; set; }
    }
}
