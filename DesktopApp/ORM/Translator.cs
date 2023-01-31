using System;
            
namespace DesktopApp.ORM
{
	public class Translator : DomainObject
	{
		public string LastName { get; set;}
		public string FirstName { get; set;}
		public DateTime? BirthDate { get; set;}
		public string Biography { get; set;}
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
