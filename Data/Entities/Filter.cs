namespace LingonberryStudio.Data.Entities
{
    public class Filter
    {
        public string? OfferingLooking { get; set; }
        public bool Offering { get; set; }
        public bool Looking { get; set; }
        public string? City { get; set; }

        public string? MonthOrWeek { get; set; }
        public bool Month { get; set; }        
        public bool Week { get; set; }
        public int Budget { get; set; }

        public bool Parking { get; set; }
        public bool AirCon { get; set; }
        public bool Kitchen { get; set; }
        public bool NaturalLight { get; set; }
        public bool AcousticTreatment { get; set; }
        public bool RunningWater { get; set; }
        public bool Storage { get; set; }
        public bool OtherAmenities { get; set; }


        public WorkPlace WorkPlaceTest { get; set; }
        public bool MusikStudio { get; set; }
        public bool ArtStudio { get; set; }
        public bool PhotoStudio { get; set; }
        public bool DanceRehersalStudio { get; set; }
        public bool CeramicsStudio { get; set; }
        public bool PaintingWorkshop { get; set; }
        public bool OtherStudio { get; set; }


        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
