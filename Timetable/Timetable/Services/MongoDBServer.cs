using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Driver.Core;
using System.Threading;
using Timetable.Models;

namespace Timetable
{

    // Help links:
    // https://docs.mongodb.com/v3.2/tutorial/install-mongodb-on-windows/
    class MongoDBServer
    {

        //Database Varaibles
        string databaseName = "timetable";
        string collectionName = "timetableEntry";

        //Elements collections
        IMongoCollection<TimetableElement> timetableElementsCollection;
        IMongoCollection<TimetableElement> TimetableElementsCollection
        {
            get
            {
                if (timetableElementsCollection == null)
                {
                    Console.WriteLine("TESTING START =============================:");
                    //Variables
                    var connectionString = "mongodb://admin:admin2019@ds119795.mlab.com:19795/timetable";
                    var client = new MongoClient(connectionString);

                    // Get function call will get the database or automatically create one if it dose not exist
                    // Returns an object which is a representation of a database
                    var db = client.GetDatabase(databaseName);

                    // Check if a collection exists, create it, and then add documents to a collection
                    timetableElementsCollection = db.GetCollection<TimetableElement>(collectionName);
                    Console.WriteLine(collectionName);
                    Console.WriteLine("END TESTING START =============================END");
                }//End if
                return timetableElementsCollection; //Return data to element collection
            }//End get
        }//End 

        //Fuctions for gettings all data for a timetable from the array list.
        //@Return all entrys for a timetable
        public async Task<List<TimetableElement>> GetAllEntrys()
        {
            Console.WriteLine("TESTING START =============================:");
            try
            { 
                //Varaibles that will find all documents in the list "timetableElementsCollection":
                var allEntrys = await timetableElementsCollection.Find(new BsonDocument()).ToListAsync();
                //Return entrys
                return allEntrys;
            }
            catch(Exception e)
            {
                //Display error message to consoles
                System.Diagnostics.Debug.WriteLine(e.Message);
            }//End try catch
            return null; //Return null
        }//End get all entrys funtion

        // Function thats creates a new timetable element:
        public async Task CreateTimetableElement(TimetableElement entry)
        {
            await TimetableElementsCollection.InsertOneAsync(entry);
        }//End create function

    }// End class 
}
