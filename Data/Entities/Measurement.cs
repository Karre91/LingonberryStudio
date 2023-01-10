using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Measurement
    {
        [Key]
        public int MeasurementID { get; set; }

        //[Required]
        public string? FeetOrMeters { get; set; }

        //[Required]
        [RegularExpression(@"^[0-9]{1,6}$",
        ErrorMessage = "Maximum 6 digits")]
        public int? Number { get; set; }
    }
}
