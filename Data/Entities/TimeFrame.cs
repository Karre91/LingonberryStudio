namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class TimeFrame
    {
        [Key]
        public int DatesAndTimeID { get; set; }

        [AllowNull]
        public DateTime? OpeningTime { get; set; }

        [AllowNull]
        public DateTime? ClosingTime { get; set; }

        [AllowNull]
        public DateTime? StartDate { get; set; }

        [AllowNull]
        public DateTime? EndDate { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        public List<bool> GetList()
        {
            List<bool> list = new List<bool>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
            return list;
        }
    }
}
