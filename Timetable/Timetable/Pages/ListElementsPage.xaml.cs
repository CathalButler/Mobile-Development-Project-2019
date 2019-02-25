using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//Help link: https://xamarinhelp.com/xamarin-forms-binding/

namespace Timetable
{
    public partial class ListElementsPage : ContentPage
    {
        //Variables
        ListElementsViewModel viewModel;

        public ListElementsPage()
        {
            InitializeComponent();

            //Instances of ListElementsViewModel
            viewModel = new ListElementsViewModel();

            // Mapping ListElementsViewModel source data, which is in ListElementsViewModel
            BindingContext = viewModel;

        }//End constructor

    }//End class
}//End namespaces
