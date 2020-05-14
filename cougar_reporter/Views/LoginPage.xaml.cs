using cougar_reporter.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using XF_Login.ViewModels;
using SQLite;
using cougar_reporter.Models;

namespace cougar_reporter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);

        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
         
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.GetUser(username.Text);
                //firebase return null value if user data not found in database    
                if (user != null)
                    if (username.Text == user.UserName && password.Text == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert(" ", "Successfully Logged In", "Ok");
                        //App.Current.MainPage = new NavigationPage(new LandingPage(user.firstName, user.UserName));
                        App.Current.MainPage = new NavigationPage(new Hamburger(user.UserName));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Failed", "Please enter correct Username and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Failed", "User not found", "OK");
            }

        }

    }
}
