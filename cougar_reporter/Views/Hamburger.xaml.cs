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
    public partial class Hamburger : MasterDetailPage
    {
        public string username;
        public Hamburger(string u)
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            username = u;
            Detail = new NavigationPage(new HomePage(username));
        }

        //submit report page
        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SubmitReport0(username));
        }

        //home page
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage(username));
        }

        //logout
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ViewTickets(username));
        }
    }
}