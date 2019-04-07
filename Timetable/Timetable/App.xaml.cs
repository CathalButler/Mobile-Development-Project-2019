using System;
using Timetable.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Timetable
{
    public class ScrollableTabbedPage : TabbedPage
    {
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Tabbled scoll for all pages for each day of the week
            var tabbedNavigation = new ScrollableTabbedPage();
            tabbedNavigation.Children.Add(new NavigationPage(new MondayTabPage()) { Title = "Monday" });
            tabbedNavigation.Children.Add(new NavigationPage(new TuesdayTabPage()) { Title = "Tuesday" });
            tabbedNavigation.Children.Add(new NavigationPage(new WednesdayTabPage()) { Title = "Wednesday" });
            tabbedNavigation.Children.Add(new NavigationPage(new ThursdayTabPage()) { Title = "Thursday" });
            tabbedNavigation.Children.Add(new NavigationPage(new FridayTabPage()) { Title = "Friday" });

            // Set main page to tabbed pages
            MainPage = tabbedNavigation;
        } // End constuctor

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
