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
	public partial class MondayTabPage : ContentPage
	{
		public MondayTabPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var module = new Module();
            var createPage = new CreatePage(module);

            Navigation.PushAsync(new NavigationPage(createPage));
        }
    }
}