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
        public event EventHandler SaveComplete;


        // Constuctor
        public CreateViewModel(Module module, string dayOfWeek)
        {
            // Add new objet
            NewModule = module;
            // Setting the day of the week depending on what day page the user selected to add a new entry.
            NewModule.DayOfWeek = dayOfWeek;

            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        // Function to make a save request to the mongo serive to then add it to the database
        public async Task ExecuteSaveCommand()
        {
            var monoService = new MongoDBServer();
            // Call to service to add a new modules to the database.
            await monoService.CreateTimetableElement(NewModule);
        } // End SaveAsync method

    }// End class
}// End namespace
