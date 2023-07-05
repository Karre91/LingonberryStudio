namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class Advert
    {
        public Advert()
        {
            TimeCreated = DateTime.Now;
            Offering = true;
            FirstName = "Default";
            LastName = "Default";
            Email = "Default";
            PhoneNumber = null;
            Artist = null;
            SocialMedia = null;
            StudioType = "Default";
            City = "Default";
            Description = "Default";
        }

        public Advert(bool offering, string firstName, string lastName, string email, string? phoneNumber, string? artist, string? socialMedia, string studioType, string city, string description)
        {
            TimeCreated = DateTime.UtcNow;
            Offering = offering;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Artist = artist;
            SocialMedia = socialMedia;
            StudioType = studioType;
            City = city;
            Description = description;
        }

        [Key]
        public int ID { get; set; }

        public DateTime TimeCreated { get; set; }/* = DateTime.Now;*/

        [Required(ErrorMessage = "This field is required")]
        public bool Offering { get; set; }

        //public bool Looking { get; set; }

        [Required(ErrorMessage = "The first name field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Not a valid Email address")]
        public string Email { get; set; }

        [AllowNull]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Not a valid Phone number")]
        public string? PhoneNumber { get; set; }

        [AllowNull]
        public string? Artist { get; set; }

        [AllowNull]
        public string? SocialMedia { get; set; }

        [Required(ErrorMessage = "The workplace field is required.")]
        public string StudioType { get; set; }

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

        public bool Parking { get; set; }

        public bool Shower { get; set; }

        public bool AirCondition { get; set; }

        public bool Kitchen { get; set; }

        public bool NaturalLight { get; set; }

        public bool AcousticTreatment { get; set; }

        public bool RunningWater { get; set; }

        public bool Storage { get; set; }

        public bool Toilet { get; set; }

        public bool CeramicOven { get; set; }

        [AllowNull]
        [RegularExpression(
            @"^[a-zA-Z''-'\s\(,)]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        public string? Other { get; set; }

        [AllowNull]
        public DateTime? OpeningTime { get; set; }

        [AllowNull]
        public DateTime? ClosingTime { get; set; }

        [AllowNull]
        public DateTime? StartDate { get; set; }

        [AllowNull]
        public DateTime? EndDate { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public List<Tuple<string, bool>> GetAllDaysTuple()
        {
            var tupleList = new List<Tuple<string, bool>>
                    {
                        Tuple.Create(nameof(Monday), Monday),
                        Tuple.Create(nameof(Tuesday), Tuesday),
                        Tuple.Create(nameof(Wednesday), Wednesday),
                        Tuple.Create(nameof(Thursday), Thursday),
                        Tuple.Create(nameof(Friday), Friday),
                        Tuple.Create(nameof(Saturday), Saturday),
                        Tuple.Create(nameof(Sunday), Sunday),
                    };

            return tupleList;
        }

        public List<Tuple<string, bool>> GetAllAmenityTuple()
        {
            bool other = false;
            if (Other is not null)
            {
                other = true;
            }

            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Parking), Parking),
                Tuple.Create(nameof(Shower), Shower),
                Tuple.Create(nameof(AirCondition), AirCondition),
                Tuple.Create(nameof(Kitchen), Kitchen),
                Tuple.Create(nameof(NaturalLight), NaturalLight),
                Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
                Tuple.Create(nameof(RunningWater), RunningWater),
                Tuple.Create(nameof(Storage), Storage),
                Tuple.Create(nameof(Toilet), Toilet),
                Tuple.Create(nameof(CeramicOven), CeramicOven),
                Tuple.Create(nameof(Other), other),
            };

            return tupleList;
        }

        public string SplitCamelCase(string formInput)
        {
            string[] split = Regex.Split(formInput, @"(?<!^)(?=[A-Z])");
            string joinedSplit = string.Join(" ", split);
            return joinedSplit;
        }
    }
}