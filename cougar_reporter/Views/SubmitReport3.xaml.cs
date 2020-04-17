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
        }
        public SubmitReport3(string _repair, string _building, string _room, string _des)
        {
            InitializeComponent();
            RepairText.Text = _repair;
            BuildingText.Text = _building;
            RoomText.Text = _room;
            Description.Text = _des;
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPage());
        }
    }
}