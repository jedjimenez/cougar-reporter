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
        //Compile other data and send to to content page
        public SubmitReport3(string _repair, string _building, string _room, string _des)
        {
            InitializeComponent();
            RepairText.Text = _repair;
            BuildingText.Text = _building;
            RoomText.Text = _room;
            Description.Text = _des;
        }
        
        //Open content page
        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            //open content page with the user's vlaues
            //await Navigation.PushAsync(new ContentPage(_repair, _building, _room, _des));
            await Navigation.PushAsync(new ContentPage());
        }
    }
}
