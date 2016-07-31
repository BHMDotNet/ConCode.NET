using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
				sessionList.IsRefreshing = true;
				_sessionList = await RefreshSessions();
				sessionList.IsRefreshing = false;
			}

			sessionList.ItemsSource = _sessionList;
		}

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			SessionListModel item = e.SelectedItem as SessionListModel;
			await Navigation.PushAsync(new SessionDetails(item));
		}

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			_sessionList = await RefreshSessions();
			sessionList.EndRefresh();
		}

		private async Task<List<SessionListModel>> RefreshSessions()
		{
			var cd = new ConferenceData();
			var sessionsListModel = await cd.GetSessionsAsync();

			return sessionsListModel;
		}
	}
}

