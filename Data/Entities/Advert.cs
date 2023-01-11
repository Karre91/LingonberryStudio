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
        public int AdvertID { get; set; } 
        public DateTime TimeCreated { get; set; } = DateTime.Now;
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
        public bool Offering { get; set; }
        [Required]
        public bool Looking { get; set; }
        [Required]
        public string City { get; set; }
        [AllowNull]
        public string? Area { get; set; }
        [AllowNull]
        public string? Artist { get; set; }
        [AllowNull]
        public string? SocialMedia { get; set; }

        [Display(Name = "WorkPlace")]
        public virtual int WorkPlaceID { get; set; }
        [ForeignKey("WorkPlaceID")]
        public virtual WorkPlace WorkPlaces { get; set; }
		[Display(Name = "Amenity")]
        public virtual int AmenityID { get; set; }
        [ForeignKey("AmenityID")]
        public virtual Amenity Amenities { get; set; }
		[Display(Name = "Budget")]
		public virtual int BudgetId { get; set; }
		[ForeignKey("BudgetID")]
		public virtual Budget Budgets { get; set; }
        [Display(Name = "Measurement")]
        public virtual int MeasurementID { get; set; }
        [ForeignKey("MeasurementID")]
        public virtual Measurement Measurements { get; set; }
        [Display(Name = "DatesAndTime")]
        public virtual int DatesAndTimeID { get; set; }
        [ForeignKey("DatesAndTimeID")]
        public virtual DatesAndTime DatesAndTimes { get; set; }
    }
}

