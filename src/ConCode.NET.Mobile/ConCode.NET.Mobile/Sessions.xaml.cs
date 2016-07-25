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

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			await Navigation.PushAsync(new SessionDetails());
		}
	}
}

