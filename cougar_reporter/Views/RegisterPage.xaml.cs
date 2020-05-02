using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Models;
using System.IO;
using SQLite;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(pswd.Text))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
               
                    //call AddUser function which we define in Firebase helper class    
                    var user = await FirebaseHelper.AddUser(username.Text, pswd.Text, type.SelectedIndex);
                    //AddUser return true if data insert successfuly     

                    if (user)
                    {
                        await this.DisplayAlert("You have sucessfully registered", "", "Ok");
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else
                        await this.DisplayAlert("Error", "SignUp Fail", "OK");
         

            }
        }

    
    }
}
//await Navigation.PushModalAsync(new LoginPage());

