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
        public int ID { get; set; }
     
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="This field is required")]
        public bool Offering { get; set; }
        [Required(ErrorMessage = "The first name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,40}$",
        ErrorMessage = "Only letters allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The last name field is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,40}$",
        ErrorMessage = "Only letters allowed.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Not a valid Email address")]
        public string Email { get; set; }
        [AllowNull]
        [RegularExpression(@"(\+\d{1,3}\s?)?((\(\d{3}\)\s?)|(\d{3})(\s|-?))(\d{3}(\s|-?))(\d{4})(\s?(([E|e]xt[:|.|]?)|x|X)(\s?\d+))?", ErrorMessage = "Not a valid Phone number")]
        public string? PhoneNumber { get; set; }
        [AllowNull]
        public string? Artist { get; set; }
        [AllowNull]
        public string? SocialMedia { get; set; }

        [Required(ErrorMessage = "The workplace field is required.")]
        public string StudioType { get; set; }


        [Display(Name = "WorkPlace")]
        public virtual int WorkPlaceID { get; set; }

        [ForeignKey("WorkPlaceID")]
        public virtual WorkPlace WorkPlace { get; set; }

        
    }
}

