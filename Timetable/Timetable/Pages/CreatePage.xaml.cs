using System;
using Xamarin.Forms;

namespace Timetable.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        private CreateViewModel _viewModel;

        public CreatePage(Module newModule)
        {
            InitializeComponent();

            _viewModel = new CreateViewModel(newModule);
            _viewModel.SaveComplete += _viewModel_SaveComplete;

            // Mapping source data, which is in CreateViewModel
            BindingContext = _viewModel;
        }

        private void _viewModel_SaveComplete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }// End class
}// End Namespace   