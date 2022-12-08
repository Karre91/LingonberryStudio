using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
        public int Price { get; set; }
    }
}
