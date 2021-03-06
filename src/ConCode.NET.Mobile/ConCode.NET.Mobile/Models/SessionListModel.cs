﻿using System;
using System.Collections.Generic;
using ConCode.NET.Domain;
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

		public IEnumerable<string> Tags
		{
			get;
			set;
		}

		public string Abstract
		{
			get;
			set;
		}
	}

}

