using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        public bool Feet { get; set; }

        public bool Meters { get; set; }

        public int Number { get; set; }
    }
}
