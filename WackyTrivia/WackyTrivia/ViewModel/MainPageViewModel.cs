using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WackyTrivia.Model;
using WackyTrivia.View;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand ViewStatsCommand { get; set; }

        public MainPageViewModel()
        {
            ViewStatsCommand = new Command(ViewStats);
        }

        public void ViewStats()
        { 
        }

        #region INPC
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
}
