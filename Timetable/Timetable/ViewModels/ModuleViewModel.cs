using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.ViewModels
{
    public class ModuleViewModel : BaseViewModel
    {



        // Day of the week
        private string _dayOfWeek;
        public string DayOfWeek
        {
            get { return _dayOfWeek; }
            set { SetProperty(ref _dayOfWeek, value); }
        }// End of dayOfweek function

        //Time
        private string _time;
        public string StartTime
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }//End time get & set funtion

        //Time
        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set { SetProperty(ref _endTime, value); }
        }//End time get & set funtion


        // Info
        private string _info;
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }//End room get & set funtion

        public async Task SaveModuleList(ObservableCollection<ModuleViewModel> saveModules)
        {
            MongoDBServer mongo = new MongoDBServer();

            //await mongo.CreateTimetableElement(saveModules);
        }


    }// End class
}// End namespace
