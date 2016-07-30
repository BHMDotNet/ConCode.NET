using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
			Navigation.PushAsync(new Home());

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
	
		}
	}
}

