using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class Speakers : ContentPage
	{
		public Speakers()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			var cd = new ConferenceData();

			speakerList.ItemsSource = await cd.GetSpeakersAsync();
		}
	}
}

