using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		public string? Title { get; set; }

		[Required(ErrorMessage = "Author is required.")]
		public string? Author { get; set; }

		[Required(ErrorMessage = "ISBN is required.")]
		public string? ISBN { get; set; }

		public bool isAvailable { get; set; } = true;

		[Required(ErrorMessage = "Published Date is required.")]
		public DateOnly PublishedDate { get; set; }
	}
}
