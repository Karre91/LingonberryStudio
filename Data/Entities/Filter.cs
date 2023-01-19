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

        public int Currency { get; set; }

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

        public bool OtherAmenities { get; set; }

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
    }
}
