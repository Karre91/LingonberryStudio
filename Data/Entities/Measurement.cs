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
        public int? Number { get; set; }
    }
}
