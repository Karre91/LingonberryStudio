using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace LingonberryStudio.Data.Entities
{
    public class Advert
    {
        public Advert()
        {
            Facilitie myFac = new();
        }
        

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string OfferingLooking { get; set; }

        [Required]
        public string WorkspaceDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PostCode { get; set; }

        public Facilitie Facilities { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public Measurement Measurements { get; set; }

        public DatesAndTime Avaliability { get; set; }

        public string Artist { get; set; }

        //public Uri SocialMedia { get; set; }
    }
}






