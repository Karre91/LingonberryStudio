using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        public string Parking { get; set; }
        public string AirCon { get; set; }
        public string Kitchen { get; set; }
        public string NaturalLight { get; set; }
        public string AcousticTreatment { get; set; }
        public string RunningWater { get; set; }
        public string Storage { get; set; }

        [AllowNull]
        public string? Other { get; set; }


        
    }
}
