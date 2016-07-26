using System;
using ConCode.NET.Core.Domain;
namespace ConCode.NET.Mobile
{
	public class SessionListModel
	{
		public SessionListModel()
		{
		}

		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string DateTime
		{
			get;
			set;
		}

		public string Level
		{
			get;
			set;
		}

		public string Length
		{
			get;
			set;
		}

		public string Venue
		{
			get;
			set;
		}

		public SessionStatus Status
		{
			get;
			set;
		}
	}

}

