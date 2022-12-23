using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
    public class DatesAndTime
    {
        [Key]
        public int DatesAndTimeId { get; set; }

        [AllowNull]
        public DateTime? StartDate { get; set; }

        [AllowNull]
        public DateTime? EndDate { get; set; }

        [AllowNull]
        public DateTime? OpeningTime { get; set; }

        [AllowNull]
        public DateTime? ClosingTime { get; set; }

        [Display(Name = "Day")]
        public virtual int DayID { get; set; }

        [ForeignKey("DayID")]
        public virtual Day Days { get; set; }
    }
}
