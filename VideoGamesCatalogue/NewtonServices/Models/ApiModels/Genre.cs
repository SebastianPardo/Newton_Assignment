using EntityGenre = NewtonServices.Models.Entities.Genre;

namespace NewtonServices.Models.ApiModels
{
    public class Genre
    {
        public Genre(EntityGenre genre)
        {
            Id = genre.Id;
            Name = genre.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
