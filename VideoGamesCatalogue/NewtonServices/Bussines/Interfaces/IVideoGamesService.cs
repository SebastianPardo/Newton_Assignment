using NewtonServices.Models.Entities;
using NewtonServices.Models.Views;

namespace NewtonServices.Bussines.Interfaces
{
    public interface IVideoGamesService
    {
        IEnumerable<VideoGame> GetAll();
        IEnumerable<VwAllVideoGames> GetAllAvailables();
        IEnumerable<VwAllVideoGames> GetAllByGenre(string genreCode);
        IEnumerable<VwAllVideoGames> GetAllByPlatform(string platformCode);
        VideoGame? GetById (Guid id);
        VideoGame Add(VideoGame videoGame);
        bool Update(VideoGame videoGame);
        bool Delete(VideoGame videoGame);
    }
}
