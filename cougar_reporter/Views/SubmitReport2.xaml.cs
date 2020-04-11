using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitReport2 : ContentPage
    {
        public SubmitReport2()
        {
            InitializeComponent();
        }

        private async void Folder_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Oops", "Pick Photo is not supported !", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if(file == null)
            {
                return;
            }

            PathLabel.Text = "Photo Path" + file.Path;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
        private async void Camera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", ":( No camera available.", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                SaveToAlbum = true,
                Directory = "Sample",
                Name = "Test.jpg"
                });

                if (file == null)
                {
                    return;
                }

                PathLabel.Text = file.AlbumPath;

                MainImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
        }
    }
}