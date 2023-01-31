using System;
            
namespace DesktopApp.ORM
{
	public class Author : DomainObject
	{
		public string LastName { get; set;}
		public string FirstName { get; set;}
		public DateTime? BirthDate { get; set;}
		public string Biography { get; set;}

		private string fullName;

		public string FullName
        {
			get
            {
				if(fullName == null)
                {
					fullName = FirstName + " " + LastName;
				}
				return fullName;
            }

			set 
			{
				fullName = value;
			}
        }
	}
}
