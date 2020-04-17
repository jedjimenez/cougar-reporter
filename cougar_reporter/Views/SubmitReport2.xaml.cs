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
        public string Rpick2;
        public string Bpick2;
        public string Entry2;
        public string Editor2;
        public SubmitReport2()
        {
            InitializeComponent();
        }
        public SubmitReport2(string repair_, string building_, string room_, string des_)
        {
            InitializeComponent();
            //receive value from SubmitReport1
            Rpick2 = repair_;
            Bpick2 = building_;
            Entry2 = room_;
            Editor2 = des_;
        }

        private async void Folder_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                //all possbile case errors
                await DisplayAlert("Oops", "Pick Photo is not supported !", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if(file == null)
            {
                return;
            }
            //Photo path
            PathLabel.Text = "Photo Path" + file.Path;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
        
        //camera click function
        private async void Camera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            
            //check for errors open camera
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", ":( No camera available.", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(
                //Save into local file
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubmitReport3(Rpick2, Bpick2, Entry2, Editor2));
        }
    }
}
