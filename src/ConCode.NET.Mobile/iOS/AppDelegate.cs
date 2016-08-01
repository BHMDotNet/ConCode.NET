using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using WatchKit;

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

		public async override void HandleWatchKitExtensionRequest(UIApplication application, NSDictionary userInfo, Action<NSDictionary> reply)
		{

			var cd = new ConferenceData();
			var sessions = await cd.GetSessionsAsync();

			var array = new NSMutableArray((nuint)sessions.Count);
			foreach (var session in sessions)
			{
				var title = string.Format("{0}|{1}", session.DateTime, session.Title);
				array.Add(FromObject(title));
			}

			reply(new NSDictionary("SessionTitle", array));
		}
	}
}

