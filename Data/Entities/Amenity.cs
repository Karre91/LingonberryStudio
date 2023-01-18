namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class Amenity
    {
        public Amenity()
        {
            Parking = false;
            Shower = false;
            AirCondition = false;
            Kitchen = false;
            NaturalLight = false;
            AcousticTreatment = false;
            RunningWater = false;
            Storage = false;
            Toilet = false;
            CeramicOven = false;
            Other = "test";
        }

        public Amenity(bool parking, bool shower, bool airCondition, bool kitchen, bool naturalLight, bool acousticTreatment, bool runningWater, bool storage, bool toilet, bool ceramicOven, string? other)
        {
            Parking = parking;
            Shower = shower;
            AirCondition = airCondition;
            Kitchen = kitchen;
            NaturalLight = naturalLight;
            AcousticTreatment = acousticTreatment;
            RunningWater = runningWater;
            Storage = storage;
            Toilet = toilet;
            CeramicOven = ceramicOven;
            Other = other;
        }

        [Key]
        public int AmenityID { get; set; }

        public bool Parking { get; set; }

        public bool Shower { get; set; }

        public bool AirCondition { get; set; }

        public bool Kitchen { get; set; }

        public bool NaturalLight { get; set; }

        public bool AcousticTreatment { get; set; }

        public bool RunningWater { get; set; }

        public bool Storage { get; set; }

        public bool Toilet { get; set; }

        public bool CeramicOven { get; set; }

        [AllowNull]
        [RegularExpression(
            @"^[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        public string? Other { get; set; }

        public List<bool> GetList()
        {
            List<bool> list = new List<bool>() { Parking, Shower, AirCondition, Kitchen, NaturalLight, AcousticTreatment, RunningWater, Storage, Toilet, CeramicOven };
            return list;
        }
    }
}
