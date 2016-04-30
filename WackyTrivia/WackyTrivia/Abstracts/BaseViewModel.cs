using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WackyTrivia.Abstracts
{
    /*
     * Class implemented from Xamarin TodoMvvm example - creates base logic for all ViewModels
     * https://github.com/conceptdev/xamarin-forms-samples/blob/master/TodoMvvm/TodoMvvm/ViewModels/BaseViewModel.cs
     */
    class BaseViewModel : INotifyPropertyChanged
    {

        public ViewModelNavigation Navigation { get; set; }
        protected BaseViewModel()
        {

        }

        //this logic attaches to all properties that should reload the view if they change
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
