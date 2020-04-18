using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Views;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitReport1 : ContentPage
    {
        //initialize value like type, building, room
        //default values for each type
        public string Rpick = "<Repair Type>";
        public string Bpick = "<Building>";
        public string Entry1 = "<Room>";
        public string Editor1 = "....";

        public SubmitReport1()
        {
            InitializeComponent();
            
            //add possible choices to pick
            RepairPicker.Items.Add("Type 1");
            RepairPicker.Items.Add("Type 2");
            RepairPicker.Items.Add("Type 3");
            RepairPicker.Items.Add("Type 4");
            BuildingPicker.Items.Add("Building 1");
            BuildingPicker.Items.Add("Building 2");
            BuildingPicker.Items.Add("Building 3");
            BuildingPicker.Items.Add("Building 4");
        }

        private void RepairPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save user pick into variable
            string name = RepairPicker.Items[RepairPicker.SelectedIndex];
            // App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            this.Rpick = name;
        }
        private void BuildingPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save user pick into variable
            var name = BuildingPicker.Items[BuildingPicker.SelectedIndex];
            //App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            this.Bpick = name;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            //change old text into new text
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            //all entries has been picked
            string text = ((Entry)sender).Text;
            this.Entry1 = text;
        }

        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
            this.Editor1 = text;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //call SubmitReport2 page and pass parameters into it
            await Navigation.PushAsync(new SubmitReport2(Rpick, Bpick, Entry1, Editor1));
        }
    }
}
