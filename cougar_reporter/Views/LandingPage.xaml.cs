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
    public partial class LandingPage : ContentPage
    {
        public string username;
        public LandingPage(string fName, string u)
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            l.Text = "Welcome " + fName + "!";
            username = u;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Hamburger(username));
        }
    }
}