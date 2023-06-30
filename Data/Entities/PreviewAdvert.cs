namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    public class PreviewAdvert
    {
        //public PreviewAdvert()
        //{
        //    TimeCreated = DateTime.Now;
        //    Offering = true;
        //    StudioType = "Default";
        //}

        //public PreviewAdvert(bool offering, string studioType)
        //{
        //    TimeCreated = DateTime.UtcNow;
        //    Offering = offering;
        //    StudioType = studioType;
        //}

        public int ID { get; set; }
        public DateTime TimeCreated { get; set; }/* = DateTime.Now;*/
        public bool Offering { get; set; }
        public string? StudioType { get; set; }
        public int? Pounds { get; set; }
        public string? ImgUrl { get; set; }
        public string? City { get; set; }
        public string? Period { get; set; }

        public string SplitCamelCase(string formInput)
        {
            string[] split = Regex.Split(formInput, @"(?<!^)(?=[A-Z])");
            string joinedSplit = string.Join(" ", split);
            return joinedSplit;
        }
    }
}
