using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Core;
using System.Threading;

namespace Timetable
{
    class Server
    {

        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            //Variables
            var connectionString = "mongodb://admin:admin2019@ds119795.mlab.com:19795/";
            var client = new MongoClient(connectionString);

            // Get function call will get the database or automatically create one if it dose not exist
            // Returns an object which is a representation of a database
            IMongoDatabase db = client.GetDatabase("timetable");

            await db.CreateCollectionAsync("timetable");

            // Check if a collection exists, create it, and then add documents to a collection
            var collection = db.GetCollection<TimetableElement>("timetable");
            var newEntrys = CreateTimetableElement();

            Console.WriteLine(newEntrys);

            await collection.InsertManyAsync(newEntrys);

        }//End main

        // Function thats creates a new timetable element:
        private static IEnumerable<TimetableElement> CreateTimetableElement()
        {
            var entry = new TimetableElement
            {
                dayOfWeek = "Monday",

            };

            var newEntrys = new List<TimetableElement> { entry };

            return newEntrys; 
        }

        // Define a day of week schema for timetable
        internal class TimetableElement
        {
            public string dayOfWeek { get; set; }
            // Array list of modules for one day eg testing right now "Monday"
            public List<Module> Modules { get; set; }

        };//End function 

        // Define a schema for module entrys
        internal class Module
        {
            public string title { get; set; }
            public string time { get; set; }
            public string room { get; set; }
        };//End function 

    }// End class 
}
