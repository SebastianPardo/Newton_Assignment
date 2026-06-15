using NewtonServices.Models.Entities;

namespace NewtonServices.Bussines.Interfaces
{
    public interface IPlatformsService
    {
        IEnumerable<Platform> GetAll();
        Platform? GetById (Guid id);
    }
}
