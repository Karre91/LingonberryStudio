using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client.Extensions.Msal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class WorkPlace
    {
        [Key]
        public int WorkPlaceID { get; set; }
        public bool MusicStudio { get; set; }
        public bool ArtStudio { get; set; }
        public bool PhotoStudio { get; set; }
        public bool DanceRehersalStudio { get; set; }
        public bool CeramicsStudio { get; set; }
        public bool PaintingWorkshop { get; set; }
        [AllowNull]
        public string? OtherStudio { get; set; }
        [AllowNull]
        public string? ImgUrl { get; set; }
        [AllowNull]
        [NotMapped]
        public IFormFile? FormFile { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,300}$",
        ErrorMessage = "Only letters allowed")]
        public string Description { get; set; }


        public List<bool> GetList()
        {
            List<bool> list = new List<bool>() { MusicStudio, ArtStudio, PhotoStudio, DanceRehersalStudio, CeramicsStudio, PaintingWorkshop};
            return list;
        }
        public Studios studios { get; set; }
    }
    public enum Studios
    {
        Music, Art, Photo, Dance, Ceramics, Painting, Workshop

    }
}
