namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Identity.Client.Extensions.Msal;

    public class WorkPlace
    {
        public WorkPlace()
        {
            City = "Default";
            Area = null;
            ImgUrl = null;
            Description = "Default";
            Period = null;
            Pounds = null;
            MeasurementNumber = null;
            MeasurementType = null;
            AmenityTypes = new Amenity();
            TimeFrames = new TimeFrame();
        }

        public WorkPlace(string city, string area, string imgUrl, IFormFile? formFile, string description, string period, int pounds, string measurementType, int measurementNumber, int amenityID, Amenity amenityTypes, int timeFrameID, TimeFrame timeFrames)
        {
            City = city;
            Area = area;
            ImgUrl = imgUrl;
            FormFile = formFile;
            Description = description;
            Period = period;
            Pounds = pounds;
            MeasurementType = measurementType;
            MeasurementNumber = measurementNumber;
            AmenityID = amenityID;
            AmenityTypes = amenityTypes;
            TimeFrameID = timeFrameID;
            TimeFrames = timeFrames;
        }

        [Key]
        public int WorkPlaceID { get; set; }

        [Required(ErrorMessage = "The city field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,60}$",
            ErrorMessage = "Only letters allowed")]
        public string City { get; set; }

        [AllowNull]
        [RegularExpression(
            @"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Only letters allowed")]
        public string? Area { get; set; }

        [AllowNull]
        public string? ImgUrl { get; set; }

        [AllowNull]
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        [Required(ErrorMessage = "The description field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s\(\)\,\\.\!\?\\\-]{1,300}$",
            ErrorMessage = "Only letters allowed")]
        public string Description { get; set; }

        [AllowNull]
        public string? Period { get; set; }

        [AllowNull]
        [RegularExpression(
            @"^[0-9]{1,6}$",
            ErrorMessage = "Maximum 6 digits")]
        public int? Pounds { get; set; }

        [AllowNull]
        public string? MeasurementType { get; set; }

        [AllowNull]
        [RegularExpression(
            @"^[0-9]{1,6}$",
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
