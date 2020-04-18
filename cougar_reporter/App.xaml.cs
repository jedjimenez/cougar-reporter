using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Services;
using cougar_reporter.Views;

namespace cougar_reporter
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(new LoginPage()); 
            tabbedPage.Children.Add(new RegisterPage()); 
            MainPage = new NavigationPage(); 
            MainPage = tabbedPage;
            
  
            //MainPage = new AppShell();
            //MainPage = new NavigationPage(new SubmitReport1());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
