using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LingonberryStudio.Data.Entities
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile? formFile { get; set; }
    }
}
