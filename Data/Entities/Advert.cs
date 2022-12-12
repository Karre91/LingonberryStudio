using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Advert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Please try again with a shorter description!")]
        public string Description { get; set; }

        //public DateTime TimeCreated { get; set; } = DateTime.Now;

        //public Uri Uri { get; set; }
    }
}
