using System.ComponentModel.DataAnnotations;

namespace NewtonServices.Models.Views
{
    public class VwAllVideoGames
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string PlatformCode { get; set; }
        public string PlatformName { get; set; }
        public string GenreCode { get; set; }
        public string Genre { get; set; }
    }
}
