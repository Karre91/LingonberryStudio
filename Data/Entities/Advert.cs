﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace LingonberryStudio.Data.Entities
{
    public class Advert
    {
        [Key]
        public int AdvertID { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,40}$",
        ErrorMessage = "Only letters allowed")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,40}$",
        ErrorMessage = "Only letters allowed.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Not a valid Email address")]
        public string Email { get; set; }

        [AllowNull]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Not a valid Phone number")]
        public int? PhoneNumber { get; set; }

        [Required]
        public bool Offering { get; set; }
        [Required]
        public bool Looking { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s-]{1,60}$",
        ErrorMessage = "Only letters allowed")]
        public string City { get; set; }

        [AllowNull]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Only letters allowed")]
        public string? Area { get; set; }

        [AllowNull]
        public string? Artist { get; set; }

        [AllowNull]
        public string? SocialMedia { get; set; }


        [Display(Name = "WorkPlace")]
        public virtual int WorkPlaceID { get; set; }

        [ForeignKey("WorkPlaceID")]
        public virtual WorkPlace WorkPlaces { get; set; }

        [Display(Name = "Amenity")]
        public virtual int AmenityID { get; set; }
        [ForeignKey("AmenityID")]
        public virtual Amenity Amenities { get; set; }

        [Display(Name = "Budget")]
        public virtual int BudgetId { get; set; }
        [ForeignKey("BudgetID")]
        public virtual Budget Budgets { get; set; }

        [Display(Name = "Measurement")]
        public virtual int MeasurementID { get; set; }
        [ForeignKey("MeasurementID")]
        public virtual Measurement Measurements { get; set; }
        [Display(Name = "DatesAndTime")]
        public virtual int DatesAndTimeID { get; set; }
        [ForeignKey("DatesAndTimeID")]
        public virtual DatesAndTime DatesAndTimes { get; set; }

        [Display(Name = "Description")]
        public virtual int DescriptionID { get; set; }

        [ForeignKey("DescriptionID")]
        public virtual Description Description { get; set; }
    }
}

