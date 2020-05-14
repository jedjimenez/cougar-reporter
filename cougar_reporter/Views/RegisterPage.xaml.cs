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

            string num = id.Text;
            int length = num.Length;

            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(pswd.Text)) //check if entry is empty
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter Email and Password", "OK");
            }
            else if (pswd.Text != confpswd.Text) //check if password matches
            {
                await App.Current.MainPage.DisplayAlert(" ", "Passwords do not match", "OK");
            }
            else if (string.IsNullOrEmpty(id.Text)) //check if entry is empty
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter CSUSM ID number", "OK");
            }
            else if (type.SelectedIndex == -1) //check if user has chosen an option
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please choose type of user", "OK");
            }
            else if (length < 9) //check if the ID Number is valid
            {
                await App.Current.MainPage.DisplayAlert(" ", "Please enter a valid CSUSM ID number", "OK");
            }
            else
            {

                var person = await FirebaseHelper.GetUser(username.Text); //check if username exists or not
                var idNum = await FirebaseHelper.GetUser1(id.Text); //check if CSUSM ID exists or not

                if (person != null)
                {
                    await this.DisplayAlert("Error", "Username already exists", "Ok");
                }
                else if (idNum != null)
                {
                    await this.DisplayAlert("Error", "CSUSM ID number already exists", "Ok");
                }
                else
                {
                    string name = type.Items[type.SelectedIndex];

                    var user = await FirebaseHelper.AddUser(fName.Text, lName.Text, username.Text, pswd.Text, name, id.Text); //add user's info to the database

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

