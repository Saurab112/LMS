﻿using Microsoft.EntityFrameworkCore;

namespace LMS.Models
{
	public class LibraryContext : DbContext
	{
		public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<BorrowRecord> BorrowRecords { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>().ToTable("Books");
			modelBuilder.Entity<BorrowRecord>().ToTable("BorrowRecords");

			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					BookId = 1,
					Title = "The Pragmatic Programmer",
					Author = "Andrew Hunt and David Thomas",
					ISBN = "978-0201616224",
					PublishedDate = new DateTime(2021, 10, 30),
					IsAvailable = true
				},
				new Book
				{
					BookId = 2,
					Title = "Design Pattern using C#",
					Author = "Robert C. Martin",
					ISBN = "978-0132350884",
					PublishedDate = new DateTime(2023, 8, 1),
					IsAvailable = true
				},
				new Book
				{
					BookId = 3,
					Title = "Mastering ASP.NET Core",
					Author = "Pranaya Kumar Rout",
					ISBN = "978-0451616235",
					PublishedDate = new DateTime(2022, 11, 22),
					IsAvailable = true
				},
				new Book
				{
					BookId = 4,
					Title = "SQL Server with DBA",
					Author = "Rakesh Kumat",
					ISBN = "978-4562350123",
					PublishedDate = new DateTime(2020, 8, 15),
					IsAvailable = true
				});
		}

	}
}
