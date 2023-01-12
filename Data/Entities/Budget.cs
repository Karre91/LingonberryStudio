using System.ComponentModel.DataAnnotations;

namespace LingonberryStudio.Data.Entities
{
	public class Budget
	{
		[Key]
		public int BudgetID { get; set; }

        public bool Month { get; set; }

        public bool Week { get; set; }

		public int Price { get; set; }
	}
}
