using EntityPlatform = NewtonServices.Models.Entities.Platform;

namespace NewtonServices.Models.ApiModels
{
    public class Platform
    {
        public Platform(EntityPlatform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
