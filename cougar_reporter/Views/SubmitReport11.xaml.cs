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
    public partial class SubmitReport11 : ContentPage
    {
        public SubmitReport11()
        {
            InitializeComponent();
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
            string name = RepairPicker.Items[RepairPicker.SelectedIndex];
            // App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            var s = new SubmitReport3("RepairType", name);
        }
        private void BuildingPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = BuildingPicker.Items[BuildingPicker.SelectedIndex];
            //App.Current.MainPage.DisplayAlert(name, "Selected", "OK");
            var s = new SubmitReport3("BuildingText", name);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }
    }
}