using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class Description
    {
        [Key]
        public int ImageID { get; set; }

        [AllowNull]
        public string? ImgUrl { get; set; }

        [AllowNull]
        [NotMapped]
        public IFormFile? formFile { get; set; }

        //[Required]
        public string? Desc { get; set; }
    }
}
