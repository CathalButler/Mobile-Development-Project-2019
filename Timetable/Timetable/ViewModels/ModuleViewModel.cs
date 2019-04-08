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
        // List of modules
        List<Module> modules;
        // Getter and Setters for modules propertys
        public List<Module> Modules { get => modules; set => SetProperty(ref modules, value); }
        private string _dayOfWeek;

        // Commands
        public ICommand DeleteCommand { get; }

        public ModuleViewModel()
        {
            // Delcared instances of list
            Modules = new List<Module>();
            // Delete Cammand used for removing a a element when a user presses on a modules listed.
            DeleteCommand = new Command<Module>(async (module) => await ExecuteDeleteCommandAsync(module));

        }// End Construtor

        public void setDayOfWeek(string dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
        }

        public string getDayOfWeek()
        {
            return _dayOfWeek;
        }

        // Function to make a call to the service to get modules for the day of week page the user is on.
        public async Task GetModulesByDayOfWeek(string dayOfWeek)
        {
            // Set day of week variable
            _dayOfWeek = dayOfWeek;
            // New instances of mongo service
            var db = new MongoDBServer();
            // Adding all modules data to modules list retrived from the mongo service
            Modules = await db.GetModulesByDay(dayOfWeek);

        }//End Function

        private async Task ExecuteDeleteCommandAsync(Module module)
        {
            // New instances of mongo service
            var db = new MongoDBServer();
            // Pass module object to serive to remove it from the database by its ID.
            await db.DeleteModule(module);
            // Update the list after delete is complete:
            Modules = await db.GetModulesByDay(_dayOfWeek);

        }// End delete function 

    }// End class
}// End namespace