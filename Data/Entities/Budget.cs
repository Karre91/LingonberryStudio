using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Data.Entities
{
	public class Budget
	{
		[Key]
		public int? BudgetID { get; set; }
		        
        public bool Month { get; set; }
        
        public bool Week { get; set; }

		public int Price { get; set; }
	}
}
