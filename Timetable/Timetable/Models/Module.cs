using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Timetable
{
    /* To keep the UI synchronized with the data source, there needs to be a way to notify the target object when the source object has changed. 
     * This mechanism is provided by the INotifyPropertyChanged interface.
     * Define a schema for module entrys to the database
     * Referance: https://blog.xamarin.com/introduction-to-data-binding/
     * https://www.codeproject.com/Articles/1023761/MVVM-and-BaseViewModel-foundations
     */

    public class Module : INotifyPropertyChanged
    {
        //Varaibles
        string title, time, room;

        [BsonId] //id for the entry in the database
        public ObjectId ID { get; set; }
        [BsonElement("title")]
        public string Title
        {
            get
            { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }//End title get & set funtion

        [BsonElement("time")]
        public string Time
        {
            get
            { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }//End time get & set funtion

        [BsonElement("room")]
        public string Room
        {
            get { return room; }
            set
            {
                if (room != value)
                {
                    room = value;
                    OnPropertyChanged("Room");
                }
            }
        }//End room get & set funtion

        /* These functions lets the applicaiton no that the propertrys have changed for the values above */
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }//End funtion



        protected void SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }
    }//End class
}
