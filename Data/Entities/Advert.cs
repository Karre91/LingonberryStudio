using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace LingonberryStudio.Data.Entities
{
    public class Advert
    {
        [Key]
        public int AdvertId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [AllowNull]
        public int? PhoneNumber { get; set; }

        [Required]
        public string OfferingLooking { get; set; }

        [Required]
        public string WorkspaceDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Display(Name = "Amenity")]
        public virtual int AmenityID { get; set; }

        [ForeignKey("AmenityID")]
        public virtual Amenity Amenities { get; set; }

        [Required]
        public int Budget { get; set; }

        //[Required]
        [Display(Name = "Measurement")]
        public virtual int MeasurementID { get; set; }

        [ForeignKey("MeasurementID")]
        public virtual Measurement Measurements { get; set; }

        [Display(Name = "DatesAndTime")]
        public virtual int DatesAndTimeID { get; set; }

        [ForeignKey("DatesAndTimeID")]
        public virtual DatesAndTime DatesAndTimes { get; set; }
        [AllowNull]
        public string? Artist { get; set; }

        
    }
}

//public Uri SocialMedia { get; set; }




