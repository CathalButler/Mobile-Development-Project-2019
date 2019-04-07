using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MondayTabPage : ContentPage
    {
        ModuleViewModel _viewModel;

        public MondayTabPage()
        {
            InitializeComponent();

            _viewModel = new ModuleViewModel();

            BindingContext = _viewModel;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var module = new Module();
            var createPage = new CreatePage(module, "Monday");

            Navigation.PushAsync(new NavigationPage(createPage));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.GetModulesByDayOfWeek("Monday");
        }
    }
}