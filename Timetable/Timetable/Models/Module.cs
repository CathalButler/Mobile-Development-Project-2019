using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Timetable.ViewModels;

namespace Timetable
{
    /* To keep the UI synchronized with the data source, there needs to be a way to notify the target object when the source object has changed. 
     * This mechanism is provided by the INotifyPropertyChanged interface.
     * Define a schema for module entrys to the database
     * Referance: https://blog.xamarin.com/introduction-to-data-binding/
     * https://www.codeproject.com/Articles/1023761/MVVM-and-BaseViewModel-foundations
     * 
     * Model is part of the domain, BaseViewModel is part of the presentation
     */

    public class Module
    {
        #region == Public Properties ==
        [BsonId] //id for the entry in the database
        public ObjectId ID { get; set; }

        // Title
        [BsonElement("title")]
        public string Title { get; set; }

        // Day of the week
        [BsonElement("dayOfWeek")]
        public string DayOfWeek { get; set; }

        //Time
        [BsonElement("start_time")]
        public string StartTime { get; set; }

        //Time
        [BsonElement("end_time")]
        public string EndTime { get; set; }

        // Info
        [BsonElement("info")]
        public string Info { get; set; }

        #endregion


        #region  == Constructors ==
        public Module() { }


        public Module(ObjectId iD, string title, string dayOfWeek, string startTime, string endTime, string info)
        {
            ID = iD;
            Title = title;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            Info = info;
        }

        #endregion

    }//End class
}
