using Microsoft.EntityFrameworkCore;
using NewtonServices.Bussines.Interfaces;
using NewtonServices.Data;
using NewtonServices.Models.Entities;
using NewtonServices.Models.Views;

namespace NewtonServices.Bussines
{
    public class VideoGamesService : IVideoGamesService
    {
        DataBaseContext _context;
        public VideoGamesService(DataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<VideoGame> GetAll() => _context.VideoGame;

        public IEnumerable<VwAllVideoGames> GetAllAvailables() => _context.VwAllVideoGames.Where(e => e.IsAvailable);

        public IEnumerable<VwAllVideoGames> GetAllByGenre(string genreCode) 
            => _context.VideoGame.Include(v => v.Genre).Include(v => v.Platform).Where(e => e.Genre.Code == genreCode)
            .Select(v => new VwAllVideoGames
            {
                Id = v.Id,
                Title = v.Title,
                Quantity = v.Quantity,
                Price = v.Price,
                IsAvailable = v.IsAvailable,
                GenreCode = v.Genre.Code,
                Genre = v.Genre.Name,
                PlatformCode = v.Platform.Code,
                Platform = v.Platform.Name
            });

        public IEnumerable<VwAllVideoGames> GetAllByPlatform(string platformCode) => _context.VwAllVideoGames.Where(e => e.PlatformCode == platformCode);

        public VideoGame? GetById(Guid id) => _context.VideoGame.SingleOrDefault(e => e.Id == id);

        public bool Exists(Guid id) => _context.VideoGame.Any(e => e.Id == id);

        public VideoGame Add(VideoGame videoGame)
        {
            VideoGame entity = _context.VideoGame.Add(videoGame).Entity;
            _context.SaveChanges();
            return entity;
        }

        public bool Update(VideoGame videoGame)
        {
            videoGame.DateUpdated = DateTime.Now;
            _context.VideoGame.Update(videoGame);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(VideoGame videoGame)
        {
            videoGame.IsAvailable = false;
            _context.VideoGame.Update(videoGame);
            return _context.SaveChanges() > 0;
        }
    }
}
