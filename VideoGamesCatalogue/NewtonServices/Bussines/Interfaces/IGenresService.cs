using NewtonServices.Models.Entities;

namespace NewtonServices.Bussines.Interfaces
{
    public interface IGenresService
    {
        IEnumerable<Genre> GetAll();
        Genre? GetById (Guid id);
    }
}
