using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }

        [AllowNull]
        public string? Name { get; set; }

        [AllowNull]
        public string? ImgUrl { get; set; }

    }
}
