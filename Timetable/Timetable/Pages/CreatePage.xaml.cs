using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timetable.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        // View Module
        private CreateViewModel _viewModel;

        public CreatePage(Module newModule, string dayOfWeek)
        {
            InitializeComponent();
             
            _viewModel = new CreateViewModel(newModule, dayOfWeek);
            _viewModel.SaveComplete += Handle_SaveCompleteAsync;

            // Mapping source data, which is in CreateViewModel
            BindingContext = _viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.SaveComplete -= Handle_SaveCompleteAsync;
        }

        private void Handle_SaveCompleteAsync(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        protected void Handle_CancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        async Task DismissPage()
        {
            await Navigation.PopAsync();
        }

    }// End class
}// End Namespace   