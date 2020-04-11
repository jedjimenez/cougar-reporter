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
    public partial class SubmitReport3 : ContentPage
    {
        public SubmitReport3()
        {
            InitializeComponent();
            RepairText.Text = "default repair";
            BuildingText.Text = "default building";
            RoomText.Text = "default room";
        }
        public SubmitReport3(string s, string value)
        {
            InitializeComponent();
            if (s == "RepairText")
            {
                RepairText.Text = value;
            }
            else if (s == "BuildingText")
            {
                BuildingText.Text = value;
            }
            else//RoomText
            {
                RoomText.Text = value;
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}