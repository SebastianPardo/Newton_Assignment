using NewtonServices.Bussines.Interfaces;
using NewtonServices.Data;
using NewtonServices.Models.Entities;

namespace NewtonServices.Bussines
{
    public class PlatformsService : IPlatformsService
    {
        DataBaseContext _context;
        PlatformsService(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public IEnumerable<Platform> GetAll() => _context.Platform;
        public Platform? GetById(Guid id) => _context.Platform.FirstOrDefault(e => e.Id == id);
    }
}
