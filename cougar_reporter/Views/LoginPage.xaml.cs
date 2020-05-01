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

        public static string uName;
        public LoginPage()
        {
            InitializeComponent();
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            //create database folder
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            //create database
            var db = new SQLiteConnection(dbpath);
            //set up query to insert into database
            var myquery = db.Table<RegisteredUsers>().Where(u => u.UserName.Equals(username.Text) && u.Password.Equals(password.Text)).FirstOrDefault();

            if (myquery != null)
            {
                uName = username.Text;
                App.Current.MainPage = new NavigationPage(new LandingPage(uName));
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //initialize all possible cases
                    // var result = await this.DisplayAlert("Error!", "Wrong username or password. Enter again.", "Yes", "Cancel");

                    await this.DisplayAlert("Error!", "Wrong username or password. Enter again.", "Yes", "Cancel");

                    /* if (result)
                         await Navigation.PushModalAsync(new LoginPage());
                     else
                         await Navigation.PushModalAsync(new LoginPage());*/


                });
            }

            //await  Navigation.PushModalAsync(new HomePage());
        }

    }
}
