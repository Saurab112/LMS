using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[Required(ErrorMessage = "Title field is required.")]
		[StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
		public string? Title { get; set; }

		[Required(ErrorMessage = "Author field is required.")]
		[StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
		public string? Author { get; set; }

		[Required(ErrorMessage = "ISBN field is required.")]
		[RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXXX.")]
		public string? ISBN { get; set; }

		[Display(Name = "Available")]
		public bool IsAvailable { get; set; } = true; //default to available

		[Required(ErrorMessage = "Published Date field is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "Published Date")]
		public DateTime PublishedDate { get; set; }

		//Navigation property
		[BindNever]
		public ICollection<BorrowRecord>? BorrowRecords { get; set; }
	}
}
