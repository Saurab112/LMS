using LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class ListingPageController : Controller
    {
        private readonly LibraryContext _db;

        public ListingPageController(LibraryContext libraryContext)
		{
			_db = libraryContext;
		}
		//public static List<Book> Books { get; set; } = new List<Book>
  //      {
  //          new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", IsAvailable = true, PublishedDate = new DateTime(1925, 4, 10) },
  //          new Book { BookId = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780060935467", IsAvailable = true, PublishedDate = new DateTime(1960, 7, 11) },
  //          new Book { BookId = 3, Title = "1984", Author = "George Orwell", ISBN = "9780451524935", IsAvailable = true, PublishedDate = new DateTime(1949, 6, 8) },
  //          new Book { BookId = 4, Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780679783268", IsAvailable = true, PublishedDate = new DateTime(1813, 1, 28) },
  //          new Book { BookId = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488", IsAvailable = true, PublishedDate = new DateTime(1951, 7, 16) }
  //      };

		public IActionResult Index()
        {
            List<Book> books = _db.Books.ToList();
			return View(books);
        }

        public IActionResult Details(int id)
        {
            Book? book = _db.Books.FirstOrDefault(b => b.BookId == id);
            if(book == null)
            {
                return NotFound();
			}
            return View(book);
		}
        public IActionResult Edit(int id)
        {
            Book? book = _db.Books.FirstOrDefault(b=>b.BookId == id);
			if (book == null)
            {
				return NotFound();
			}
			return View(book);
		}
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Book? bookToEdit = _db.Books.FirstOrDefault(b => b.BookId == book.BookId);
			if(bookToEdit != null)
			{
				bookToEdit.Title = book.Title;
				bookToEdit.Author = book.Author;
				bookToEdit.ISBN = book.ISBN;
				bookToEdit.PublishedDate = book.PublishedDate;
			}
            _db.SaveChanges();
			return RedirectToAction("Index");
		}
        public IActionResult Create()
        {
			return View();
		}
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
			//Entity framework automatically creates id as its the primary key
			//book.BookId = _db.Books.Max(b => b.BookId) + 1;
            _db.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
		public IActionResult Delete(int id)
        {
            Book? book = _db.Books.FirstOrDefault(b => b.BookId == id);
			if (book == null)
			{
				return NotFound();
			}
			return View(book);
		}
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            Book? bookToDelete = _db.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if(bookToDelete == null)
            {
                return NotFound();
            }
            _db.Remove(bookToDelete);
			_db.SaveChanges();
			return RedirectToAction("Index");
        }
        public IActionResult Borrow(int id)
        {
            Book? book = _db.Books.FirstOrDefault(b => b.BookId == id);
			return View(book);
		}
    }
}
