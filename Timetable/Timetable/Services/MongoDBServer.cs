using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Core;
using System.Threading;
using Timetable.ViewModels;

namespace Timetable
{

    // Help links:
    // https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-windows/
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
    // https://blog.xamarin.com/introduction-to-data-binding/
    class MongoDBServer
    {
        // Member Varaibles
        private IMongoClient _mongoClient;
        private IMongoDatabase _database;
        private IMongoCollection<ModuleViewModel> _timetableElementsCollection;
        //Database Varaibles
        string databaseName = "timetable";
        string collectionName = "timetable_list";
        string connectionString = "mongodb://admin:admin2019@ds119795.mlab.com:19795/timetable";

        public MongoDBServer() // Constructor
        {
            // Connect to databata server with connection url:
            _mongoClient = new MongoClient(connectionString);
       
            // Call will get the database or automatically create one if it dose not exist
            // Returns an object which is a representation of a database
            _database = _mongoClient.GetDatabase(databaseName);

            // Check if a collection exists, create it, and then add documents to a collection 
            _timetableElementsCollection = _database.GetCollection<ModuleViewModel>(collectionName);

        }//End constructor

        //Fuctions for gettings all data for a timetable from the list.
        //@Return all entrys for a timetable
        public async Task<List<ModuleViewModel>> GetAllEntrys()
        {
            try
            {
                //Varaibles that will find all elements in the list "timetableElementsCollection":
                var allEntrys = await _timetableElementsCollection.Find(new BsonDocument()).ToListAsync();
                //Return entrys
                return allEntrys;
            }
            catch (Exception e)
            {
                //Display error message to consoles
                System.Diagnostics.Debug.WriteLine(e.Message);
            }//End try catch
            return null; //Return null
        }//End get all entrys funtion


        // Function thats creates a new timetable element:
        public async Task CreateTimetableElement(ModuleViewModel entrys)
        {
            Console.WriteLine("Create object: " + entrys );
            Console.ReadLine();
            await _timetableElementsCollection.InsertOneAsync(entrys);
        }//End create function

    }// End class 
}// End namespace
