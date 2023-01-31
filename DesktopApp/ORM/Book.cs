using System;
using System.Collections.ObjectModel;

namespace DesktopApp.ORM
{
	public class Book : DomainObject
	{
		public string Title { get; set;}
		//public string TitleLower { get; set;}
		public int? ReleaseYear { get; set;}
		public string Description { get; set;}
		//public int AuthorId { get; set;}
		//public int LanguageId { get; set;}

		public Author Author { get; set; }
		public Language Language { get; set; }
		public Collection<BookCopy> BookCopies { get; set; }
		public Collection<Genre> Genres { get; set; }

		public string AuthorFullName { get { return Author.FullName; } }
	}
}
