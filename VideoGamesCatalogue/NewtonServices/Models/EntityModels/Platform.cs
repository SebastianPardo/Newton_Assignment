using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonServices.Models.EntityModels
{
    [Table("Platforms")]
    public class Platform
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        // Navigation property for related VideoGames
        
        public virtual ICollection<VideoGame>? VideoGames { get; set; }

    }
}
