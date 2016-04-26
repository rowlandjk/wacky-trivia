using System.ComponentModel;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using WackyTrivia.View;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class MainPageViewModel : BaseViewModel
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
            var game = new GameViewModel();
            Navigation.Push(ViewFactory.CreatePage(game));
        }

        public void ViewStats()
        {
            var stats = new StatsPageViewModel();
            Navigation.Push(ViewFactory.CreatePage(stats));
        }
    }
}
