using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Timetable
{

    public class ListElementsViewModel : Module 
    {
        //Varaibles
        List<Module> modules;
        // Method that gets all data for each module and sets the values
        public List<Module> Modules { get => modules; set => SetProperty(ref modules, value); }

        //Constructor
        public ListElementsViewModel()
        {
            //List that will hold all the elements that make up the timetable:
            Modules = new List<Module>();

            GetAllTasksAsync();
        }//End constructor

        public async Task GetAllTasksAsync()
        {
            var mongoDB = new MongoDBServer();
            Modules = await mongoDB.GetAllEntrys();
    
        }//End function

        public async Task createEntryAsync()
        {
            //var mongoDB = new MongoDBServer();
           // await mongoDB.CreateTimetableElement();
        }//End function


    }//End class
}//End namespace
