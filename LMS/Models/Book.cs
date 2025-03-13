namespace LMS.Models
{
	public class Book
	{
		public int BookId { get; set; }
		public string? Title { get; set; }
		public string? Author { get; set; }
		public string? ISBN { get; set; } // Fixed the type of ISBN property
		public bool isAvailable { get; set; }
		public DateOnly PublishedDate { get; set; }
	}
}
