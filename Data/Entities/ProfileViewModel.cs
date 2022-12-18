using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class ProfileViewModel
    {
        [Key]
        public int PwmID { get; set; }

        [AllowNull]
        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
