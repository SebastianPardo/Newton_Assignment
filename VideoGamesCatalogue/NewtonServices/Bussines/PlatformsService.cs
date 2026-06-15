using NewtonServices.Bussines.Interfaces;
using NewtonServices.Data;
using NewtonServices.Models.Entities;

namespace NewtonServices.Bussines
{
    public class PlatformsService : IPlatformsService
    {
        DataBaseContext _context;
        public PlatformsService(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }
        public IEnumerable<Platform> GetAll() => _context.Platform;
        public Platform? GetByCode(string code) => _context.Platform.SingleOrDefault(e => e.Code == code);
    }
}
