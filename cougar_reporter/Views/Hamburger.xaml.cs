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
        public Hamburger()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            Detail = new NavigationPage(new HomePage());
        }

        //submit report page
        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SubmitReport1());
        }

        //home page
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
        }

        //logout
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ViewTickets());
        }
    }
}