namespace LingonberryStudio.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public enum OrderBy
    {
        /// <summary>
        /// Order by newest ad first.
        /// </summary>
        [Description("Date: Newest first")]
        DateNewToOld,

        /// <summary>
        /// Order by oldest ad first.
        /// </summary>
        [Description("Date: Oldest first")]
        DateOldToNew,

        /// <summary>
        /// Order by lowest price first.
        /// </summary>
        [Description("Price: Low -> High")]
        PriceLowToHigh,

        /// <summary>
        /// Order by highest price first.
        /// </summary>
        [Description("Price: High -> Low")]
        PriceHighToLow,
    }

    public class Filter
    {
        public bool Offering { get; set; }

        public bool Looking { get; set; }

        public string? City { get; set; }

        public bool Month { get; set; }

        public int Pounds { get; set; }

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

        public OrderBy OrderBy { get; set; }

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

            List<string> checkedSudios = new();
            foreach (var tuple in tupleList)
            {
                if (tuple.Item2)
                {
                    checkedSudios.Add(tuple.Item1);
                }
            }

            return checkedSudios;
        }

        public List<Tuple<string, bool>> GetAllAmenityTuple()
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

            return tupleList;
        }

        public List<Tuple<string, bool>> GetAllDaysTuple()
        {
            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Monday), Monday),
                Tuple.Create(nameof(Tuesday), Tuesday),
                Tuple.Create(nameof(Wednesday), Wednesday),
                Tuple.Create(nameof(Thursday), Thursday),
                Tuple.Create(nameof(Friday), Friday),
                Tuple.Create(nameof(Saturday), Saturday),
                Tuple.Create(nameof(Sunday), Sunday),
            };

            return tupleList;
        }
    }
}
