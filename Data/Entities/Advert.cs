using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace LingonberryStudio.Data.Entities
{
    public class Advert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Please try again with a shorter description!")]
        public string Description { get; set; }

        [Required]
        public string OfferingLooking { get; set; }


        [Required]
        public string WorkspaceDescription { get; set; }

        [Required]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string ArtistName { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Days { get; set; }

        public int Budget { get; set; }

        public string PostCode { get; set; }

        public string Area { get; set; }

        public Uri SocialMedia { get; set; }

        public string Facilities { get; set; }




    }
}

 



 