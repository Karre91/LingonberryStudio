namespace LingonberryStudio.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Models;

    public class AdvertViewMoldel
    {
        public AdvertViewMoldel()
        {
            Advert = new Advert();
            Filter = new Filter();
            AdvertList = new List<Advert>();
        }

        public List<Advert> AdvertList { get; set; }

        public Filter Filter { get; set; }

        public Advert Advert { get; set; }

        public int? MaxBudget { get; set; }
    }
}
