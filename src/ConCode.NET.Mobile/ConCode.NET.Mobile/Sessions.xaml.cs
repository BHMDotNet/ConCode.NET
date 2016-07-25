using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class Sessions : ContentPage
	{
		public Sessions()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			var cd = new ConferenceData();

			listView.ItemsSource = await cd.GetSessionsAsync();
		}
	}
}

