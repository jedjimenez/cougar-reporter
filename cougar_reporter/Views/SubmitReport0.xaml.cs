using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitReport0 : TabbedPage
    {
        /*
        public string Rpick = "<Repair Type>";
        public string Bpick = "<Building>";
        public string Entry1 = "<Room>";
        public string Editor1 = "....";*/
        public SubmitReport0()
        {
            InitializeComponent();
            //add possible choices to pick
            RepairPicker.Items.Add("Damage");
            RepairPicker.Items.Add("Cleanliness");
            RepairPicker.Items.Add("Cosmetic");
            RepairPicker.Items.Add("Technical");
            RepairPicker.Items.Add("Electrical");
            RepairPicker.Items.Add("Plumbing");
            RepairPicker.Items.Add("Equipment");
            RepairPicker.Items.Add("Other");
            BuildingPicker.Items.Add("Academic Hall");
            BuildingPicker.Items.Add("Arts Building");
            BuildingPicker.Items.Add("Markstein Hall");
            BuildingPicker.Items.Add("Craven Hall");
            BuildingPicker.Items.Add("Kellog Library");
            BuildingPicker.Items.Add("Science Hall I");
            BuildingPicker.Items.Add("Science Hall II");
            BuildingPicker.Items.Add("SBSB");
            BuildingPicker.Items.Add("SHCS");
            BuildingPicker.Items.Add("University Hall");
            BuildingPicker.Items.Add("USU");
            RepairText.Text = "<Repair Type>";
            BuildingText.Text = "<Building>";
            RoomText.Text = "<Room>";
            Description.Text = "...";
        }

        private void RepairPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save user pick into variable
            string name = RepairPicker.Items[RepairPicker.SelectedIndex];
            // App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            //this.Rpick = name;
            RepairText.Text = name;
        }

        private void BuildingPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save user pick into variable
            var name = BuildingPicker.Items[BuildingPicker.SelectedIndex];
            //App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            //this.Bpick = name;
            BuildingText.Text = name;
        }

        private void RoomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            //change old text into new text
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        private void RoomNumber_Completed(object sender, EventArgs e)
        {
            //all entries has been picked
            string text = ((Entry)sender).Text;
            //this.Entry1 = text;
            RoomText.Text = text;
        }

        private void UserText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        private void UserText_Completed(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
            //this.Editor1 = text;
            Description.Text = text;
        }

        private async void FolderButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //all possbile case errors
                await DisplayAlert("Oops", "Pick Photo is not supported !", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
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

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            //check for errors open camera
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
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

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            //open content page with the user's vlaues
            //await Navigation.PushAsync(new ContentPage(_repair, _building, _room, _des));
            await Navigation.PushAsync(new ContentPage());
        }
    }
}