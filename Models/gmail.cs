namespace LingonberryStudio.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class Gmail
    {
        [AllowNull]
        public string? To { get; set; }

        [Required]
        [RegularExpression(
            @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",
            ErrorMessage = "Not a valid Email address")]
        public string? From { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        [RegularExpression(
            @"^[a-zA-Z''-'\s-]{1,60}$",
            ErrorMessage = "Only letters allowed")]
        public string? Name { get; set; }
    }
}
