using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
        [Required]
        public IFormFile formFile { get; set; }
    }
}
