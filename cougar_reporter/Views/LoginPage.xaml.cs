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
                //firebase return null valuse if user data not found in database    
                if (user != null)
                    if (username.Text == user.UserName && password.Text == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        App.Current.MainPage = new NavigationPage(new LandingPage(user.UserName));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }

        }

    }
}
