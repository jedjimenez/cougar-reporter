using System.Collections.Generic;
using Xamarin.Forms;

namespace cougar_reporter
{
    public partial class ListViewItem : ContentPage
    {
        public IList<ViewModels.ItemClass> Tasks { get; private set; }

        public ListViewItem()
        {
            InitializeComponent();

            Tasks = new List<ViewModels.ItemClass>();
            Tasks.Add(new ViewModels.ItemClass
            {
                Name = "Task1: Library Work",
                Location = "Work Description need to be done",
                ImageUrl = "https://www.csusm.edu/communications/images/branding-images/spirit-logo01.jpg"
            });

            Tasks.Add(new ViewModels.ItemClass
            {
                Name = "Task2: Library Computer Broke",
                Location = "Work Description need to be done",
                ImageUrl = "https://www.csusm.edu/communications/images/branding-images/spirit-logo01.jpg"
            });

            Tasks.Add(new ViewModels.ItemClass
            {
                Name = "Task3: Room 206 Computer out",
                Location = "Work Description need to be done",
                ImageUrl = "https://www.csusm.edu/communications/images/branding-images/spirit-logo01.jpg"
            });

            Tasks.Add(new ViewModels.ItemClass
            {
                Name = "Task4: Room 5503 wall crack",
                Location = "Work Description need to be done",
                ImageUrl = "https://www.csusm.edu/communications/images/branding-images/spirit-logo01.jpg"
            });

            Tasks.Add(new ViewModels.ItemClass
            {
                Name = "Task5: Parking Lot F needs cleaning",
                Location = "Work Description need to be done",
                ImageUrl = "https://www.csusm.edu/communications/images/branding-images/spirit-logo01.jpg"
            });


            BindingContext = this;
        }
    }
}