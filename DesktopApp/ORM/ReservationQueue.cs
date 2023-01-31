using System;
            
namespace DesktopApp.ORM
{
	/// <summary>
	/// key order: 1. user_id, 2. book_copy_id
	/// </summary>
	public class ReservationQueue : DomainObject
	{
		public int QueuePosition { get; set;}
		public DateTime? EndDate { get; set;}

		//nebo mit dalsi tridu Reservation, kde to bude
		public string BookCopyInfo { get; set; }
	}
}
