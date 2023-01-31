using Newtonsoft.Json;
using System;
            
namespace DesktopApp.ORM
{
	public class Info : DomainObject
	{
		public int ReservationDurationDays { get; set;}
		public int ReservationPenaltyDays { get; set;}
		public int BorrowingDurationDays { get; set;}
		public int BeforeClosingDateDays { get; set;}
		public int QueuesPerUser { get; set;}

        public override string ToString()
        {
			return JsonConvert.SerializeObject(this);
        }
    }
}
