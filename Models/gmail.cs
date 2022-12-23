using System.Diagnostics.CodeAnalysis;

namespace LingonberryStudio.Models
{
	public class gmail
	{
		[AllowNull]
		public string ?To { get; set; }
		public string From { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string Name { get; set; }

	}
}
