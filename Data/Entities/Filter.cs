namespace LingonberryStudio.Data.Entities
{
    using System.Collections.Generic;

    public class Filter
    {
        //public Filter(bool offering, bool looking, string? City,)
        //{

        //}

        public bool Offering { get; set; }

        public bool Looking { get; set; }

        public string? City { get; set; }

        public string? Period { get; set; }

        public int Pounds { get; set; }

        public int CalculatedPounds { get; set; }

        public bool MusicStudio { get; set; }

        public bool ArtStudio { get; set; }

        public bool PhotoStudio { get; set; }

        public bool DanceRehersalStudio { get; set; }

        public bool CeramicsStudio { get; set; }

        public bool PaintingWorkshop { get; set; }

        public bool OtherStudio { get; set; }

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

        public bool Other { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public List<string> GetChosenStudioTypes()
        {
            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(MusicStudio), MusicStudio),
                Tuple.Create(nameof(ArtStudio), ArtStudio),
                Tuple.Create(nameof(PhotoStudio), PhotoStudio),
                Tuple.Create(nameof(DanceRehersalStudio), DanceRehersalStudio),
                Tuple.Create(nameof(CeramicsStudio), CeramicsStudio),
                Tuple.Create(nameof(PaintingWorkshop), PaintingWorkshop),
                Tuple.Create(nameof(OtherStudio), OtherStudio),
            };

            List<string> checkedSudios = new ();
            foreach (var tuple in tupleList)
            {
                if (tuple.Item2)
                {
                    checkedSudios.Add(tuple.Item1);
                }
            }

            return checkedSudios;
        }

        public List<string> GetString()
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
                Tuple.Create(nameof(Other), Other),
            };

            List<string> checkedAmenitys = tupleList.Where(amenity => amenity.Item2.Equals(true)).Select(tuple => tuple.Item1).ToList();

            return checkedAmenitys;
        }

        public List<Tuple<string, bool>> GetTuple()
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
                Tuple.Create(nameof(Other), Other),
            };

            List<Tuple<string, bool>> tuple = tupleList.Select(tuple => tuple).ToList();

            return tuple;
        }

        public List<bool> GetAllBool()
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
                Tuple.Create(nameof(Other), Other),
            };

            List<bool> checkedAmenitys = tupleList.Select(tuple => tuple.Item2).ToList();

            return checkedAmenitys;
        }
    }
}
