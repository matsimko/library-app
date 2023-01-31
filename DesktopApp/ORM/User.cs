using Newtonsoft.Json;
using System;

namespace DesktopApp.ORM
{
	public class User : DomainObject
	{
		public string LastName { get; set;}
		public string FirstName { get; set;}
		public string NationalIdNum { get; set;}
		public string HomeAddr { get; set;}
		public string EmailAddr { get; set;}
		public int SuperUser { get; set;}
		public DateTime? LastLoginDatetime { get; set;}
		public DateTime? CannotReserveUntilDate { get; set;}
		public string Password { get; set;}

        public override string ToString()
        {
			return JsonConvert.SerializeObject(this);
        }
    }
}
