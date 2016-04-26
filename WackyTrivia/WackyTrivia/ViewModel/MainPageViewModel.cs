using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using WackyTrivia.Data;
using WackyTrivia.View;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class MainPageViewModel : BaseViewModel
    {
        public string TestItem { get; set; }
        public ICommand PlayGameCommand { get; set; }
        public ICommand ViewStatsCommand { get; set; }

        public MainPageViewModel()
        {
            var itemList = App.Database.GetItems().ToList();
            TestItem = itemList[0].Name;
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
