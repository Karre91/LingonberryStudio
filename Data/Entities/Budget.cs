using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
	public class Budget
	{
		[Key]
		public int BudgetID { get; set; }

        [Required]
        public bool Month { get; set; }

        [Required]
        public bool Week { get; set; }

        [Required]
		public int Price { get; set; }
	}
}
