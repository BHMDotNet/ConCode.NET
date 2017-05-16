using System;
using System.Collections.Generic;
using WatchKit;
using Foundation;

namespace ConCode.NET.Mobile.iOS.WatchKitExtension
{
	public partial class InterfaceController : WKInterfaceController
	{
		protected InterfaceController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);
			UpdateUserInterface();
		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);

		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}

		void UpdateUserInterface()
		{
			WKInterfaceController.OpenParentApplication(new NSDictionary(), (replyInfo, error) =>
			{
				if (error != null)
				{
					Console.WriteLine(error);
					return;
				}

				var events = (NSArray)replyInfo["SessionTitle"];

				MyTable.SetNumberOfRows((nint)events.Count, "default");

				for (int i = 0; i < (int)events.Count; i++)
				{
					var elementRow = (RowController)MyTable.GetRowController(i);
					elementRow.MyLabel.SetText(events.GetItem<NSString>((nuint)i));
				}
			});

		}
	}
}

