using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models;
using Xamarin.Forms;

namespace Timetable
{
    public partial class MainPage : ContentPage
    {
        List<TimetableElement> timetableElements;

        public MainPage()
        {
            InitializeComponent();
            GetTimetable();
        }

        async Task GetTimetable()
        {
            Console.WriteLine("TESTING");
            var mongo = new MongoDBServer();
            timetableElements = await mongo.GetAllEntrys();

        }//End function


    }//End class
}
