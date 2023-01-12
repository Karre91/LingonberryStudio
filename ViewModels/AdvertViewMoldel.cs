using LingonberryStudio.Data.Entities;

namespace LingonberryStudio.ViewModels
{
	public class AdvertViewMoldel
	{
        //public AdvertViewMoldel()
        //{
        //    Filter = new();
        //}

        public List<Advert>? AdvertList { get; set; }

        public Filter? Filter { get; set; }
    }
}
