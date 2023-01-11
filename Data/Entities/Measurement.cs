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

        [AllowNull]
        public int? Number { get; set; }
    }
}
