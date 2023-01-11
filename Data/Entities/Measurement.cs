using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class Measurement
    {
        [Key]
        public int MeasurementID { get; set; }
        public bool Feet { get; set; }
        public bool Meters { get; set; }

        //[Required]
        public string? FeetOrMeters { get; set; }

        //[Required]
        [RegularExpression(@"^[0-9]{1,6}$",
        ErrorMessage = "Maximum 6 digits")]
        public int? Number { get; set; }
    }
}
