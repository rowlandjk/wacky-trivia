using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using WackyTrivia.Data;
using WackyTrivia.View;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    /* ViewModel for the MainPage of WackyTrivia - Contains buttons to view stats or start the game
     * Author: Jesse Rowland
     */
    class MainPageViewModel : BaseViewModel
    {
        //button command to start a new game
        public ICommand PlayGameCommand { get; set; }
        //button command to view player stats
        public ICommand ViewStatsCommand { get; set; }

        public MainPageViewModel()
        {
            //bind button commands to the view
            PlayGameCommand = new Command(PlayGame);
            ViewStatsCommand = new Command(ViewStats);
        }
        
        //push a new game to the application
        public void PlayGame()
        {
            var game = new GameViewModel();
            Navigation.Push(ViewFactory.CreatePage(game));
        }

        //push the player's stats page to the application
        public void ViewStats()
        {
            var stats = new StatsPageViewModel();
            Navigation.Push(ViewFactory.CreatePage(stats));
        }
    }
}
