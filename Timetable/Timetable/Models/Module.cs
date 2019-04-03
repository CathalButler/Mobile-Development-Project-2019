using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        [BsonId] //id for the entry in the database
        public ObjectId ID { get; set; }

        string _title;
        [BsonElement("title")]
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;

                _title = value;

                OnPropertyChanged();
            }
        }//End title get & set funtion

        // Day of the week
        string _dayOfWeek;
        [BsonElement("dayOfWeek")]
        public string DayOfWeek
        {
            get => _dayOfWeek;
            set
            {
                if (_dayOfWeek == value)
                    return;

                _dayOfWeek = value;

                OnPropertyChanged();
            }
        }// End of dayOfweek function

        //Time
        string _time;
        [BsonElement("start_time")]
        public string StartTime
        {
            get => _time;
            set
            {
                if (_time == value)
                    return;

                _time = value;

                OnPropertyChanged();
            }
        }//End time get & set funtion

        //Time
        string _endTime;
        [BsonElement("end_time")]
        public string EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime == value)
                    return;

                _endTime = value;

                OnPropertyChanged();
            }
        }//End time get & set funtion


        // Info
        string _info;
        [BsonElement("info")]
        public string Info
        {
            get => _info;
            set
            {
                if (_info == value)
                    return;

                _info = value;

                OnPropertyChanged();

            }
        }//End room get & set funtion

        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }//End class
}
