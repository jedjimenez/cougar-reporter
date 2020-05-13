using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Models;
using System.IO;


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


            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(pswd.Text))
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter Email and Password", "OK");
            }
            else if (pswd.Text != confpswd.Text)
            {
                await App.Current.MainPage.DisplayAlert(" ", "Passwords do not match", "OK");
            }
            else if (string.IsNullOrEmpty(id.Text))
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter CSUSM ID number", "OK");
            }
            else if (type.SelectedIndex == -1)
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please choose type of user", "OK");
            }
            else
            {

                var person = await FirebaseHelper.GetUser(username.Text);
                if (person != null)
                {
                    await this.DisplayAlert("Error", "Username already exists", "Ok");
                }
                else
                {
                    string name = type.Items[type.SelectedIndex];

                    var user = await FirebaseHelper.AddUser(fName.Text, lName.Text, username.Text, pswd.Text, name, id.Text);

                    if (user)
                    {
                        await this.DisplayAlert(" ", "You have sucessfully registered", "Ok");
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else
                        await this.DisplayAlert("Error", "Signing Up Failed", "OK");

                }
            }
        }

    
    }
}

