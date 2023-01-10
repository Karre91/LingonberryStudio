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
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,300}$",
       ErrorMessage = "Only letters allowed")]
        public string? Desc { get; set; }
    }
}
