using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConCode.NET.Mobile
{
	public partial class SpeakerDetails : ContentPage
	{
		public SpeakerDetails()
		{
			InitializeComponent();
		}

		public SpeakerDetails(SpeakerListModel speakerListModel)
		{
			InitializeComponent();

			Name.Text = speakerListModel.FullName;
			Photo.Source = speakerListModel.Photo;
			Bio.Text = speakerListModel.Bio;
		}
	}
}

