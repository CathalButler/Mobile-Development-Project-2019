using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timetable.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        private CreateViewModel _viewModel;

        public CreatePage(Module newModule, string dayOfWeek)
        {
            InitializeComponent();

            _viewModel = new CreateViewModel(newModule, dayOfWeek);
            _viewModel.SaveComplete += _viewModel_SaveComplete;

            // Mapping source data, which is in CreateViewModel
            BindingContext = _viewModel;
        }

        private void _viewModel_SaveComplete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected async void Handle_CancelClicked(object sender, EventArgs e)
        {
            await DismissPage();
        }

        async Task DismissPage()
        {

            await Navigation.PopAsync();
        }

    }// End class
}// End Namespace   