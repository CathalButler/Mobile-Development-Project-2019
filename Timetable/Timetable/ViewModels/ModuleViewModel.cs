using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Timetable
{
    public class ModuleViewModel : BaseViewModel
    {
        List<Module> modules;
        public List<Module> Modules { get => modules; set => SetProperty(ref modules, value); }

        public ICommand GetDataCommand { get; }

        public ModuleViewModel()
        {
            Modules = new List<Module>();
        }

        // Function to make a call to the service to get modules for the day of week page the user is on.
        public async Task GetModulesByDayOfWeek(string dayOfWeek)
        {
            var db = new MongoDBServer();
            Modules = await db.GetModulesByDay(dayOfWeek);

        }//End Function
    }
}