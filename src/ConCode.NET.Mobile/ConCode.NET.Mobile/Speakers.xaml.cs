using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class Speakers : ContentPage
	{
		private List<SpeakerListModel> _speakerList;
		public Speakers()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (_speakerList == null)
			{
				Loading.IsVisible = true;
				Loading.IsRunning = true;

				var cd = new ConferenceData();
				_speakerList = await cd.GetSpeakersAsync();

				Loading.IsVisible = false;
				Loading.IsRunning = false;
			}

			speakerList.ItemsSource = _speakerList;
		}

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			await Navigation.PushAsync(new SpeakerDetails());
		}

		void Handle_Refreshing(object sender, System.EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}

