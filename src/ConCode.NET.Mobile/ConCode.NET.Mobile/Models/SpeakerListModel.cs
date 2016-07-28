using System;
namespace ConCode.NET.Mobile
{
	public class SpeakerListModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string TagLine { get; set; }
		public string Bio { get; set; }
		public Uri Photo { get; set; }

		public SpeakerListModel()
		{
			
		}
	}
}

