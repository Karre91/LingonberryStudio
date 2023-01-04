using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        public bool Parking { get; set; }
        public bool AirCon { get; set; }
        public bool Kitchen { get; set; }
        public bool NaturalLight { get; set; }
        public bool AcousticTreatment { get; set; }
        public bool RunningWater { get; set; }
        public bool Storage { get; set; }

        [AllowNull]
        public string? Other { get; set; }


        
    }
}
