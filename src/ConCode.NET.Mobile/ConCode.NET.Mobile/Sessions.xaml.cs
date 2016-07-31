using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class Sessions : ContentPage
	{
		private List<SessionListModel> _sessionList;
		public Sessions()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (_sessionList == null)
			{
				Loading.IsVisible = true;
				Loading.IsRunning = true;

				var cd = new ConferenceData();
				_sessionList = await cd.GetSessionsAsync();

				Loading.IsVisible = false;
				Loading.IsRunning = false;
			}

			listView.ItemsSource = _sessionList;

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

