using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    /*  ViewModel for the Stats Page for a player - currently uses fake information
     *  Todo: Implement a Player data model to track stats, will be implemented
     *  when player login is introduced.
     *  Author: Jesse Rowland
     */
    class StatsPageViewModel : BaseViewModel
    {
        //Button to exit back to the MainPage
        public ICommand ExitStatsCommand { get; set; }

        public StatsPageViewModel()
        {
            //Bind button commands to the view
            ExitStatsCommand = new Command(ExitStats);
        }

        //Go back to the MainPage
        public void ExitStats()
        {
            Navigation.Pop();
        }
    }
}
