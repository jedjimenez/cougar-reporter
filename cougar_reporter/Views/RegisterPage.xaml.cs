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
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
              
                Email = email.Text,
                Password = pswd.Text, 
          


            };
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations!", "User registration successfull", "Yes", "Cancel");

                if (result)
                    await Navigation.PushModalAsync(new LoginPage());

            }


            );
        }

        public async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}