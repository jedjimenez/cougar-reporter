using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cougar_reporter.Models;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(string u)
        {
            InitializeComponent();
            
        }

        private void Previous(object sender, EventArgs e)
        {
            int count = 0;

            if (count == 0)
            {
             
                building.Text = "Science Hall II";
                room.Text = "420";
                date.Text = "4/20/2020";
                description.Text = "broken keyboard";
                repairType.Text = "Damage";
                
            }

         
        }
        private void Next(object sender, EventArgs e)
        {
            int count = 0;

            if (count == 0)
            {
                building.Text = "Science Hall II";
                room.Text = "235";
                date.Text = "5/14/2020";
                description.Text = "broken screen projector";
                repairType.Text = "Equipment";   
            }
         
        }
    }
}
