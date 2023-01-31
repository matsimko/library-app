using Newtonsoft.Json;
using System;
            
namespace DesktopApp.ORM
{
	public class Borrowing : DomainObject
	{
		public DateTime BorrowDate { get; set;}
		public DateTime? ReturnDate { get; set;}
		public DateTime ClosingDate { get; set;}
		public int BookCopyId { get; set;}
		//public int UserId { get; set;}

		public User User { get; set; }

		public string BookCopyInfo { get; set; }

        public override string ToString()
        {
			return JsonConvert.SerializeObject(this);
        }

		public string UserFirstName { get { return User.FirstName; } }
		public string UserLastName { get { return User.LastName; } }
		public string UserNationalIdNum{ get { return User.NationalIdNum; } }
	}
}
