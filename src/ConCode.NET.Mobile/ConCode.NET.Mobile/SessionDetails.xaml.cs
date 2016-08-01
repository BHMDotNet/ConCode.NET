using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class SessionDetails : ContentPage
	{
		public SessionDetails()
		{
			InitializeComponent();
		}

		public SessionDetails(SessionListModel sessionListModel)
		{
			InitializeComponent();
			Time.Text = sessionListModel.DateTime;
			Venue.Text = sessionListModel.Venue;
			Status.Text = sessionListModel.Status.ToString();
			Title.Text = sessionListModel.Title;
			Abstract.Text = sessionListModel.Abstract;

		}
	}
}

