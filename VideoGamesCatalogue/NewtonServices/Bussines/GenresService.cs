using NewtonServices.Bussines.Interfaces;
using NewtonServices.Data;
using NewtonServices.Models.Entities;

namespace NewtonServices.Bussines
{
    public class GenresService : IGenresService
    {
        DataBaseContext _context;
        GenresService(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IEnumerable<Genre> GetAll() => _context.Genre;
        public Genre? GetById(Guid id) => _context.Genre.FirstOrDefault(e => e.Id == id);
    }
}
