using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WackyTrivia.ViewModel;
using Xamarin.Forms;

namespace WackyTrivia.View
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        public void PlayGame(object sender, EventArgs e)
        {
            var game = new GameView();
            game.BindingContext = new GameViewModel();
            Navigation.PushAsync(game);
        }
    }
}
