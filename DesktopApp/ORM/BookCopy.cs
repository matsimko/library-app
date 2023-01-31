using System;
            
namespace DesktopApp.ORM
{
	public class BookCopy : DomainObject
	{
		public int? ReleaseYear { get; set;}
		public int BookId { get; set;}
		public DateTime CreationDate { get; set;}
		//public int? TranslatorId { get; set;}
		//public int LanguageId { get; set;}

		public Translator Translator { get; set; }
		public Language Language { get; set; }

		public bool? IsBorrowed { get; set; }
		public int? PeopleInQueueCount { get; set; }


		public string TranslatorFullName { get { return Translator.FullName; } }
		public string LanguageName { get { return Language.Name; } }

		public string ReserveText { get { return IsBorrowed == true ? "Pøidat se do fronty" : "Rezervovat"; } }

	}
}
