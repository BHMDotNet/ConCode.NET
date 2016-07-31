using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
				speakerList.IsRefreshing = true;

				_speakerList = await RefreshSpeakers();

				speakerList.IsRefreshing = false;
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

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			_speakerList = await RefreshSpeakers();
			speakerList.EndRefresh();
		}

		private async Task<List<SpeakerListModel>> RefreshSpeakers()
		{
			var cd = new ConferenceData();
			var speakerListModel = await cd.GetSpeakersAsync();

			return speakerListModel;
		}
	}
}

