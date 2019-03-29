using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Timetable.ViewModels
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
            Console.WriteLine("TESTING OUTPUT FOR MODULE OBJECT: " + NewModule);
            Console.ReadLine();
            var monoService = new MongoDBServer();

          //  await monoService.CreateTimetableElement(NewModule as ModuleViewModel);

            SaveComplete?.Invoke(this, new EventArgs());
        } // End SaveAsync method


    }// End class
}// End namespace
