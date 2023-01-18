namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class Advert
    {
        [Key]
        public int ID { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;

        [Required]
        public bool Offering { get; set; }

        [Required]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed")]
        public string? FirstName { get; set; }

        [Required]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed.")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Not a valid Email address")]
        public string? Email { get; set; }

        [AllowNull]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Not a valid Phone number")]
        public int? PhoneNumber { get; set; }

        [AllowNull]
        public string? Artist { get; set; }

        [AllowNull]
        public string? SocialMedia { get; set; }

        [Required]
        public string? StudioType { get; set; }

        [Display(Name = "WorkPlace")]
        public virtual int WorkPlaceID { get; set; }

        [ForeignKey("WorkPlaceID")]
        public virtual WorkPlace? WorkPlace { get; set; }
    }
}