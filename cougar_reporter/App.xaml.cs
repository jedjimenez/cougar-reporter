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
            //DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(new LoginPage()); 
            tabbedPage.Children.Add(new RegisterPage()); 
            MainPage = new NavigationPage(); 
            MainPage = tabbedPage; 
            
            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new SubmitReport11());

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
