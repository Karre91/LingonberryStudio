﻿namespace LingonberryStudio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class Advert
    {
        public Advert()
        {
            TimeCreated = DateTime.Now;
            Offering = true;
            FirstName = "Default";
            LastName = "Default";
            Email = "Default";
            PhoneNumber = null;
            Artist = null;
            SocialMedia = null;
            StudioType = "Default";
            WorkPlace = new WorkPlace();
        }

        public Advert(bool offering, string firstName, string lastName, string email, string? phoneNumber, string? artist, string? socialMedia, string studioType, WorkPlace workPlace)
        {
            TimeCreated = DateTime.UtcNow;
            Offering = offering;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Artist = artist;
            SocialMedia = socialMedia;
            StudioType = studioType;
            WorkPlace = workPlace;
        }

        [Key]
        public int ID { get; set; }

        public DateTime TimeCreated { get; set; }/* = DateTime.Now;*/

        [Required(ErrorMessage = "This field is required")]
        public bool Offering { get; set; }

        [Required(ErrorMessage = "The first name field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The last name field is required.")]
        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,40}$",
            ErrorMessage = "Only letters allowed.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Not a valid Email address")]
        public string Email { get; set; }

        [AllowNull]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Not a valid Phone number")]
        public string? PhoneNumber { get; set; }

        [AllowNull]
        public string? Artist { get; set; }

        [AllowNull]
        public string? SocialMedia { get; set; }

        [Required(ErrorMessage = "The workplace field is required.")]
        public string StudioType { get; set; }

        [Display(Name = "WorkPlace")]
        public virtual int WorkPlaceID { get; set; }

        [ForeignKey("WorkPlaceID")]
        public virtual WorkPlace WorkPlace { get; set; }

        public string SplitCamelCase(string formInput)
        {
            string[] split = Regex.Split(formInput, @"(?<!^)(?=[A-Z])");
            string joinedSplit = string.Join(" ", split);
            return joinedSplit;
        }
    }
}