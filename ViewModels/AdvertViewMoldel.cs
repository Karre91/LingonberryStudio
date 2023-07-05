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

            PreviewAdvertList = new List<PreviewAdvert>();
        }

        public List<PreviewAdvert> PreviewAdvertList { get; set; }

        public Filter Filter { get; set; }

        public Advert Advert { get; set; }

        public int? MaxBudget { get; set; }
    }
}
