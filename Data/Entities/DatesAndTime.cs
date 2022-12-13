using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class DatesAndTime
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        //[AllowNull]
        public Day? WeekDays { get; set; }
        //public bool Monday { get; set; }
        //public bool Tuesday { get; set; }
        //public bool Wednesday { get; set; }
        //public bool Thursday { get; set; }
        //public bool Friday { get; set; }
        //public bool Saturday { get; set; }
        //public bool Sunday { get; set; }
    }
}
