using LingonberryStudio.Data.Entities;

namespace LingonberryStudio.ViewModels
{
	public class AdvertViewMoldel
	{
        public AdvertViewMoldel()
        {
            WorkPlace = new();
        }
        public List<string>? WorkPlace { get; set; }
        public Tuple<bool, string> testT { get; set; }


        public List<Advert>? AdvertList { get; set; }

        public string? OfferingLooking { get; set; }

        public string? City { get; set; }

        public string? MonthOrWeek { get; set; }

        public int Budget { get; set; }

        public bool Parking { get; set; }
        public bool AirCon { get; set; }

        //public bool MusikStudio { get; set; }
        //public bool ArtStudio { get; set; }
        //public bool PhotoStudio { get; set; }
        //public bool DanceRehersalStudio { get; set; }
        //public bool CeramicsStudio { get; set; }
        //public bool PaintingWorkshop { get; set; }
        //public bool OtherStudio { get; set; }





    }
}
