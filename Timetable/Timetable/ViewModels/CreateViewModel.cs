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
        public CreateViewModel(Module module)
        {
            // Add new objet
            NewModule = module;

            Console.WriteLine("Object: " + NewModule);
            Console.ReadLine();

            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        // Function to make a save request to the mongo serive to then add it to the database
        public async Task ExecuteSaveCommand()
        {
            var monoService = new MongoDBServer();

            await monoService.CreateTimetableElement(NewModule);
        } // End SaveAsync method

    }// End class
}// End namespace
