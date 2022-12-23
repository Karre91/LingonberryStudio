using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
	public class Budget
	{
		[Key]
		public int BudgetId { get; set; }

		//[Required]
		public string? MonthOrWeek { get; set; }

		//[Required]
		public int? Price { get; set; }
	}
}
