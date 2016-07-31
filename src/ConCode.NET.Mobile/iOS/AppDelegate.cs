using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;

namespace ConCode.NET.Mobile.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			Xamarin.FormsMaps.Init();

				UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
			UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(200,43,46);


			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

