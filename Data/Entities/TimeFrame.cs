namespace LingonberryStudio.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class TimeFrame
    {
        public TimeFrame()
        {
            OpeningTime = null;
            ClosingTime = null;
            StartDate = null;
            EndDate = null;
            Monday = false;
            Tuesday = false;
            Wednesday = false;
            Thursday = false;
            Friday = false;
            Saturday = false;
            Sunday = false;
        }

        public TimeFrame(DateTime? openingTime, DateTime? closingTime, DateTime? startDate, DateTime? endDate, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            StartDate = startDate;
            EndDate = endDate;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;
        }

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

        public List<string> GetChosenDaysList()
        {
            var tupleList = new List<Tuple<string, bool>>
            {
                Tuple.Create(nameof(Monday), Monday),
                Tuple.Create(nameof(Tuesday), Tuesday),
                Tuple.Create(nameof(Wednesday), Wednesday),
                Tuple.Create(nameof(Thursday), Thursday),
                Tuple.Create(nameof(Friday), Friday),
                Tuple.Create(nameof(Saturday), Saturday),
                Tuple.Create(nameof(Sunday), Sunday),
            };

            List<string> checkedDays = new ();
            foreach (var tuple in tupleList)
            {
                if (tuple.Item2)
                {
                    checkedDays.Add(tuple.Item1);
                }
            }

            return checkedDays;
        }
    }
}
