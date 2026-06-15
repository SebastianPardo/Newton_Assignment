using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtonServices.Models.Entities
{
    [Table("VideoGames")]
    public class VideoGame
    {
        [Key]
        public Guid Id { get; set;  } = Guid.NewGuid();

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        // Foreign keys

        [Required]
        [ForeignKey(nameof(Genre))]
        public Guid GenreId { get; set; }
        public virtual Genre? Genre { get; set; }


        [Required]
        [ForeignKey(nameof(Platform))]
        public Guid PlatformId { get; set; }
        public virtual Platform? Platform { get; set; }
    }
}
