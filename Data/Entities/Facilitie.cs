using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Facilitie
    {
        [Key]
        public int Id { get; set; }

        public bool Parking { get; set; }
        public bool AirCon { get; set; }
        public bool Kitchen { get; set; }
        public bool NaturalLight { get; set; }
        public bool AcousticTreatment { get; set; }
        public bool RunningWater { get; set; }
        public bool Storage { get; set; }
        public string Other { get; set; }
    }
}
