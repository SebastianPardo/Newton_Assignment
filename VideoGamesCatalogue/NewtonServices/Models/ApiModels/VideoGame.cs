using NewtonServices.Models.Views;

namespace NewtonServices.Models.ApiModels
{
    public class VideoGame
    {
        public VideoGame(VwAllVideoGames vwAllVideoGames)
        {
            Id = vwAllVideoGames.Id;
            Title = vwAllVideoGames.Title;
            Quantity = vwAllVideoGames.Quantity;
            Price = vwAllVideoGames.Price;
            Platform = vwAllVideoGames.Platform;
            Genre = vwAllVideoGames.Genre;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
    }
}
