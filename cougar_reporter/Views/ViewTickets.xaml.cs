using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cougar_reporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTickets : TabbedPage
    {
        public static string username;
        public ViewTickets(string u)
        {
            InitializeComponent();
            username = u;
        }
    }
}