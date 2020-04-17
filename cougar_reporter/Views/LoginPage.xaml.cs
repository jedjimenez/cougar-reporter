using cougar_reporter.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Login.ViewModels;
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

        }

       async private void Button_Clicked(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.Email.Equals(username.Text) && u.Password.Equals(password.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error!", "Wrong username or password. Enter again.", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushModalAsync(new LoginPage());
                    else
                        await Navigation.PushModalAsync(new LoginPage());


                });
            }

            //await  Navigation.PushModalAsync(new HomePage());
        }
    }
}