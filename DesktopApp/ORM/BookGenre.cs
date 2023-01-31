using System;
            
namespace DesktopApp.ORM
{
	/// <summary>
	/// key order: 1. book_id, 2. genre_id
	/// </summary>
	public class BookGenre : DomainObject
	{
		public Genre Genre { get; set; }
	}
}
