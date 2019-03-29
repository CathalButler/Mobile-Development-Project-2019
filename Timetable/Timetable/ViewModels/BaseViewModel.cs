using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Timetable.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        // Method is used to get propertry values around the applcaiton whent this class is included.
        // Set as a generic type, so anything can be passed to it.
        protected void SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "")
        {
            // Cant use == to compare generic objects, you need to declase the if like so:
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return; // Return on result 

            // backingStore is passed by value so change is not persisent, so we pass it back as a referance
            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        // Protected method
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // Interface
        public event PropertyChangedEventHandler PropertyChanged;
    }// End class
}// End namespace

