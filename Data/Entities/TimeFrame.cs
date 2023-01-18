﻿namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class TimeFrame
    {
        public TimeFrame()
        {
            OpeningTime = DateTime.Now;
            ClosingTime = DateTime.Now;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
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
    }
}
