using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
    public class Day
    {
        [Key]
        public int DayID { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }


        public List<bool> GetList()
        {
            List<bool> list = new List<bool>() { Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday};
            return list;
        }
    }
}
