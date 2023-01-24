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
            Other = null;
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

        public List<string> GetChosenAmenityList()
        {
            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Parking), Parking),
                Tuple.Create(nameof(Shower), Shower),
                Tuple.Create(nameof(AirCondition), AirCondition),
                Tuple.Create(nameof(Kitchen), Kitchen),
                Tuple.Create(nameof(NaturalLight), NaturalLight),
                Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
                Tuple.Create(nameof(RunningWater), RunningWater),
                Tuple.Create(nameof(Storage), Storage),
                Tuple.Create(nameof(Toilet), Toilet),
                Tuple.Create(nameof(CeramicOven), CeramicOven),
            };

            List<string> checkedAmenitys = new ();
            foreach (var tuple in tupleList)
            {
                if (tuple.Item2)
                {
                    checkedAmenitys.Add(tuple.Item1);
                }
            }

            return checkedAmenitys;
        }

        //public List<string> GetCheckedAmenitiesList()
        //{
        //    bool other = false;
        //    if (Other is not null)
        //    {
        //        other = true;
        //    }

        //    var tupleList = new List<Tuple<string, bool>>
        //    {
        //        Tuple.Create(nameof(Parking), Parking),
        //        Tuple.Create(nameof(Shower), Shower),
        //        Tuple.Create(nameof(AirCondition), AirCondition),
        //        Tuple.Create(nameof(Kitchen), Kitchen),
        //        Tuple.Create(nameof(NaturalLight), NaturalLight),
        //        Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
        //        Tuple.Create(nameof(RunningWater), RunningWater),
        //        Tuple.Create(nameof(Storage), Storage),
        //        Tuple.Create(nameof(Toilet), Toilet),
        //        Tuple.Create(nameof(CeramicOven), CeramicOven),
        //        Tuple.Create(nameof(Other), other),
        //    };

        //    List<string> checkedAmenitys = tupleList.Where(amenity => amenity.Item2.Equals(true)).Select(tuple => tuple.Item1).ToList();

        //    //List<Tuple<string, bool>> test = tupleList.Where(amenity => amenity.Item2.Equals(true)).Select(tuple => tuple).ToList();

        //    //return test;

        //    return checkedAmenitys;
        //}

        public List<string> GetString()
        {
            bool other = false;
            if (Other is not null)
            {
                other = true;
            }

            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Parking), Parking),
                Tuple.Create(nameof(Shower), Shower),
                Tuple.Create(nameof(AirCondition), AirCondition),
                Tuple.Create(nameof(Kitchen), Kitchen),
                Tuple.Create(nameof(NaturalLight), NaturalLight),
                Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
                Tuple.Create(nameof(RunningWater), RunningWater),
                Tuple.Create(nameof(Storage), Storage),
                Tuple.Create(nameof(Toilet), Toilet),
                Tuple.Create(nameof(CeramicOven), CeramicOven),
                Tuple.Create(nameof(Other), other),
            };

            List<string> checkedAmenitys = tupleList.Where(amenity => amenity.Item2.Equals(true)).Select(tuple => tuple.Item1).ToList();

            return checkedAmenitys;
        }

        public List<Tuple<string, bool>> GetTuple()
        {
            bool other = false;
            if (Other is not null)
            {
                other = true;
            }

            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Parking), Parking),
                Tuple.Create(nameof(Shower), Shower),
                Tuple.Create(nameof(AirCondition), AirCondition),
                Tuple.Create(nameof(Kitchen), Kitchen),
                Tuple.Create(nameof(NaturalLight), NaturalLight),
                Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
                Tuple.Create(nameof(RunningWater), RunningWater),
                Tuple.Create(nameof(Storage), Storage),
                Tuple.Create(nameof(Toilet), Toilet),
                Tuple.Create(nameof(CeramicOven), CeramicOven),
                Tuple.Create(nameof(Other), other),
            };

            List<Tuple<string, bool>> tuple = tupleList.Where(amenity => amenity.Item2.Equals(true)).Select(tuple => tuple).ToList();

            return tuple;
        }

        public List<bool> GetAllBool()
        {
            bool other = false;
            if (Other is not null)
            {
                other = true;
            }

            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Parking), Parking),
                Tuple.Create(nameof(Shower), Shower),
                Tuple.Create(nameof(AirCondition), AirCondition),
                Tuple.Create(nameof(Kitchen), Kitchen),
                Tuple.Create(nameof(NaturalLight), NaturalLight),
                Tuple.Create(nameof(AcousticTreatment), AcousticTreatment),
                Tuple.Create(nameof(RunningWater), RunningWater),
                Tuple.Create(nameof(Storage), Storage),
                Tuple.Create(nameof(Toilet), Toilet),
                Tuple.Create(nameof(CeramicOven), CeramicOven),
                Tuple.Create(nameof(Other), other),
            };

            List<bool> checkedAmenitys = tupleList.Select(tuple => tuple.Item2).ToList();

            return checkedAmenitys;
        }
    }
}
