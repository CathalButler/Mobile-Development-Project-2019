using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WednesdayTabPage : ContentPage
	{
        ModuleViewModel _viewModel;
        private string dayOfWeek = "Wednesday";

        public WednesdayTabPage()
        {
            InitializeComponent();

            // New instances of ViewModel class and setting the it as the binding context
            _viewModel = new ModuleViewModel();
            BindingContext = _viewModel;

            listOfModules.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                // Set selected module from listview
                var selectedModule = e.SelectedItem as Module;
                // Navigate to create page to edit it.
                Navigation.PushAsync(new CreatePage(selectedModule, dayOfWeek));
            };

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var module = new Module();

            Navigation.PushAsync(new CreatePage(module, dayOfWeek));
        }

        // Function to fetch all data when the page appears.
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.GetModulesByDayOfWeek(dayOfWeek);
        }
    }
}
