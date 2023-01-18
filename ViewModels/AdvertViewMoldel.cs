namespace LingonberryStudio.ViewModels
{
    using LingonberryStudio.Data.Entities;
    public class AdvertViewMoldel
    {
        public AdvertViewMoldel()
        {
            Advert = new Advert();

            // WorkPlace = new WorkPlace();
            // TimeFrame = new TimeFrame();
            // Amenity = new Amenity();
        }

        public List<Advert>? AdvertList { get; set; }

        public Filter? Filter { get; set; }

        public Advert Advert { get; set; }

        //public WorkPlace WorkPlace { get; set; }

        //public TimeFrame TimeFrame { get; set; }

        //public Amenity Amenity { get; set; }
    }
}
