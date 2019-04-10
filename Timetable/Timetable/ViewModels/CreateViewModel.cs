using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Timetable
{

    public class CreateViewModel : BaseViewModel
    {

        public Module NewModule { get; set; }
        public ICommand SaveCommand { get; }
        private bool _existingModule;

        public event EventHandler SaveComplete;


        // Constuctor
        public CreateViewModel(Module module, string dayOfWeek, bool existingModule)
        {
            // Add new objet
            NewModule = module;
            // Setting the day of the week depending on what day page the user selected to add a new entry.
            NewModule.DayOfWeek = dayOfWeek;
            _existingModule = existingModule;

            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        // Function to make a save request to the mongo serive to then add it to the database
        public async Task ExecuteSaveCommand()
        {
            var monoService = new MongoDBServer();
            // Call to service to add a new modules to the database.
            if (_existingModule)
            {
                await monoService.CreateTimetableElement(NewModule);
            }
            else
            {
                await monoService.UpdateModule(NewModule);
            } // End SaveAsync method

            SaveComplete?.Invoke(this, new EventArgs());

        }// End Save Command function
    }// End class
}// End namespace
