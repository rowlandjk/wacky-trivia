using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WackyTrivia.Model;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand PlayGameCommand { get; set; }
        public ICommand ViewStatsCommand { get; set; }

        public MainPageViewModel()
        {
            PlayGameCommand = new Command(PlayGame);
            ViewStatsCommand = new Command(ViewStats);
        }

        public void PlayGame()
        {
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
