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

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,60}$",
        ErrorMessage = "Only letters allowed")]
        public string City { get; set; }
        [AllowNull]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Only letters allowed")]
        public string? Area { get; set; }

        [AllowNull]
        public string? ImgUrl { get; set; }
        [AllowNull]
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,300}$",
        ErrorMessage = "Only letters allowed")]
        public string Description { get; set; }


        [AllowNull]
        public string? Period { get; set; }
        [AllowNull]
        public int? Currency { get; set; }


        [AllowNull]
        public string? MeasurementType { get; set; }
        [AllowNull]
        [RegularExpression(@"^[0-9]{1,6}$",
        ErrorMessage = "Maximum 6 digits")]
        public int? MeasurementNumber { get; set; }



        [Display(Name = "Amenity")]
        public virtual int AmenityID { get; set; }
        [ForeignKey("AmenityID")]
        public virtual Amenity AmenityTypes { get; set; }


        [Display(Name = "TimeFrame")]
        public virtual int TimeFrameID { get; set; }
        [ForeignKey("TimeFrameID")]
        public virtual TimeFrame TimeFrames { get; set; }



    
    }

}
