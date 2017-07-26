using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using System.Collections.Generic;
using L06mabob.Models;

namespace L06mabob
{
    public partial class _L06mabobPage : ContentPage
    {
        public _L06mabobPage()
        {
            InitializeComponent();
        }

		async void Handle_ClickedAsync(object sender, System.EventArgs e)
		{
            List<gingerbeer> quoteList = await AzureManager.AzureManagerInstance.getTable();

			Quotes.ItemsSource = quoteList;
		}

		private async void loadCamera(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera available.", "OK");
				return;
			}

			MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				PhotoSize = PhotoSize.Medium,
				Directory = "Sample",
				Name = $"{DateTime.UtcNow}.jpg"
			});

			if (file == null)
				return;

			image.Source = ImageSource.FromStream(() =>
			{
				return file.GetStream();
			});

			file.Dispose();
		}
    }
}
