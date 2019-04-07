using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Pages

{
    // Help Links
    // https://forums.xamarin.com/discussion/102811/how-to-delete-an-item-from-a-listview-in-mvvm
    // https://stackoverflow.com/questions/45941761/xamarin-forms-listview-deletion-of-items-holds-old-values
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MondayTabPage : ContentPage
    {
        ModuleViewModel _viewModel;

        public MondayTabPage()
        {
            InitializeComponent();

            // New instances of ViewModel class and setting the it as the binding context
            _viewModel = new ModuleViewModel();
            BindingContext = _viewModel;


        }// End Constructor

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var module = new Module();
            var createPage = new CreatePage(module, "Monday");

            Navigation.PushAsync(new NavigationPage(createPage));
        }

        // Function to fetch all data when the page appears.
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.GetModulesByDayOfWeek("Monday");
        }
    }
}