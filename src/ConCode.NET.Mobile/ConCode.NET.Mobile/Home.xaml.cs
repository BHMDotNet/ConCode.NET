using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Linq;

namespace ConCode.NET.Mobile
{
	public partial class Home : ContentPage
	{
		private ConferenceInfoModel _conferenceInfo;

		public Home()
		{
			InitializeComponent();
		}


		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (_conferenceInfo == null)
			{
				var cd = new ConferenceData();
				_conferenceInfo = await cd.GetConferenceInfoAsync();

				Title.Text = _conferenceInfo.Name;
				Description.Text = _conferenceInfo.Description;

				var geoCoder = await new Geocoder().GetPositionsForAddressAsync(_conferenceInfo.Location);

				Map.MoveToRegion(MapSpan.FromCenterAndRadius(geoCoder.FirstOrDefault(), new Distance(100)));
			}
		}
	}
}

